﻿using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Solicitudes : ClaseMaestra
    {
        public int SolicitudId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Asunto { get; set; }

        List<SolicitudDetalles> Detalle;

        public Solicitudes()
        {
            this.SolicitudId = 0;
            this.UsuarioId = 0;
            this.FechaCreacion = DateTime.Now;
            this.Asunto = "";
            Detalle = new List<SolicitudDetalles>();
        }

        public void AgregarSolicitud(int EleccionDestino, int TipoSolicitudId, int CompaniaId, int CategoriaId, int OrigenId, int DestinoId, DateTime FechaInicial, DateTime FechaFinal, int CantidadPersona, int CantidadNino, int CantidadBebe, double PrecioInicial, double PrecioFinal)
        {
            Detalle.Add(new SolicitudDetalles(EleccionDestino, TipoSolicitudId, CompaniaId, CategoriaId, OrigenId, DestinoId, FechaInicial, FechaFinal, CantidadPersona, CantidadNino, CantidadBebe, PrecioInicial, PrecioFinal));
        }

        public override bool Insertar()
        {
            int retorno = 0;
            ConexionDB Conexion = new ConexionDB();
            object Identity;

            try
            {
                Identity = Conexion.ObtenerDatos(string.Format("insert into Solicitudes(UsuarioId,FechaCreacion,Asunto) values({0},'{1}','{2}') select @@Identity ", this.UsuarioId, this.FechaCreacion, this.Asunto));

                int.TryParse(Identity.ToString(), out retorno);

                this.SolicitudId = retorno;

                foreach (SolicitudDetalles item in this.Detalle)
                {
                    Conexion.Ejecutar(string.Format("insert into SolicitudDetalles(EleccionDestino,SolicitudId,TipoSolicitudId,CompaniaId,CategoriaId,OrigenId,DestinoId,FechaInicial,FechaFinal,CantidadPersona,CantidadNino,CantidadBebe,PrecioInicial,PrecioFinal) values({0},{1},{2},{3},{4},{5},{6},'{7}','{8}',{9},{10},{11},{12},{13}) ", retorno, (int)item.EleccionDestino, (int)item.CompaniaId, (int)item.CategoriaId, (int)item.OrigenId, (int)item.DestinoId, (DateTime)item.FechaIncial, (DateTime)item.FechaFinal, (int)item.CantidadPersona, (int)item.CantidadNino, (int)item.CantidadBebe, (double)item.PrecioInicial, (double)item.PrecioFinal));
                }
            }
            catch (Exception)
            {
                retorno = 0;
            }

            return retorno > 0;
        }

        public override bool Editar()
        {
            int retorno = 0;
            object Identity;
            ConexionDB Conexion = new ConexionDB();

            try
            {
                Identity = Conexion.ObtenerDatos(string.Format("Update Solicitudes set UsuarioId = {0}, FechaCreacion = '{1}', Asunto = '{2}' where SolicitudId = {3} select @@Identity", this.UsuarioId, this.FechaCreacion, this.Asunto, this.SolicitudId));

                int.TryParse(Identity.ToString(), out retorno);

                this.SolicitudId = retorno;

                Conexion.Ejecutar(string.Format("Delete from SolicitudDetalles where SolicitudId = {0}", Identity));

                foreach (SolicitudDetalles item in this.Detalle)
                {
                    Conexion.Ejecutar(string.Format("insert into SolicitudDetalles(EleccionDestino,SolicitudId,TipoSolicitudId,CompaniaId,CategoriaId,OrigenId,DestinoId,FechaInicial,FechaFinal,CantidadPersona,CantidadNino,CantidadBebe,PrecioInicial,PrecioFinal) values({0},{1},{2},{3},{4},{5},{6},'{7}','{8}',{9},{10},{11},{12},{13}) ", retorno, (int)item.EleccionDestino, (int)item.CompaniaId, (int)item.CategoriaId, (int)item.OrigenId, (int)item.DestinoId, (DateTime)item.FechaIncial, (DateTime)item.FechaFinal, (int)item.CantidadPersona, (int)item.CantidadNino, (int)item.CantidadBebe, (double)item.PrecioInicial, (double)item.PrecioFinal));
                }
            }
            catch (Exception)
            {
                retorno = 0;
            }

            return retorno > 0;
        }

        public override bool Eliminar()
        {
            bool retorno = false;
            ConexionDB Conexion = new ConexionDB();

            try
            {
                retorno = Conexion.Ejecutar(string.Format("Delete from SolicitudDetalles where SolicitudId = {0}", this.SolicitudId));
                retorno = Conexion.Ejecutar(string.Format("Delete from Solicitudes where SolicitudId = {0} ", this.SolicitudId));
            }
            catch (Exception)
            {

                retorno = false;
            }

            return retorno;
        }

        public override bool Buscar(int IdBuscado)
        {
            bool retorno = false;
            DataTable dt = new DataTable();
            DataTable Detalledt = new DataTable();
            ConexionDB Conexion = new ConexionDB();

            try
            {
                dt = Conexion.ObtenerDatos(string.Format("select * from Solicitudes where SolicitudId = {0} ", IdBuscado));

                if (dt.Rows.Count > 0)
                {
                    this.SolicitudId = (int)dt.Rows[0]["SolicitudId"];
                    this.UsuarioId = (int)dt.Rows[0]["UsuarioId"];
                    this.FechaCreacion = (DateTime)dt.Rows[0]["FechaCreacion"];
                    this.Asunto = dt.Rows[0]["Asunto"].ToString();
                    retorno = true;
                }

                Detalledt = Conexion.ObtenerDatos(string.Format("select * from SolicitudDetalles where SolicitudId = {0} ", this.SolicitudId));

                if (Detalledt.Rows.Count > 0)
                {
                    foreach (DataRow Dr in Detalledt.Rows)
                    {
                        AgregarSolicitud((int)Dr["EleccionDestino"], (int)Dr["TipoSolicitudId"], (int)Dr["CompaniaId"], (int)Dr["CategoriaId"], (int)Dr["OrigenId"], (int)Dr["DestinoId"], (DateTime)Dr["FechaIncial"], (DateTime)Dr["FechaFinal"], (int)Dr["CantidadPersona"], (int)Dr["CantidadNino"], (int)Dr["CantidadBebe"], (double)Dr["PrecioInicial"], (double)Dr["PrecioFinal"]);
                    }
                    retorno = true;
                }
                else
                {
                    retorno = false;
                }
            }
            catch (Exception)
            {
                retorno = false;
            }

            return retorno;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            ConexionDB Conexion = new ConexionDB();

            try
            {
                return Conexion.ObtenerDatos(string.Format("select " + Campos + " From Solicitudes where " + Condicion + " " + Orden));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
