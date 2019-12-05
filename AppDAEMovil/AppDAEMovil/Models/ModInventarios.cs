﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AppDAEMovil.Models
{
    public class zt_cat_productos { 
        public int idSKU { get; set; }
        [StringLength(20)]
        public string CodigoBarras { get; set; }
        [StringLength(20)]
        public string DesSKU { get; set; }
        public string IdGrupoSKU { get; set; }

        public string IdUMedidaBase { get; set; }

        public DateTime FechaReg { get; set; }
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioMod { get; set; }
        public string Activo { get; set; }

        public string Borrado { get; set; }

    }
    public class zt_inventarios_acumulados
    {
        public int IdInventario { get; set; }
        [StringLength(20)]
        public string IdSKU { get; set; }
        [StringLength(10)]
        public string IdUnidadMedida { get; set; }
        public Nullable<double> CantidadTeorica { get; set; }
        public Nullable<double> CantidadTeoricaCJA { get; set; }
        public Nullable<double> CantidadFisica { get; set; }
        public Nullable<double> CantidadFisicaCJA { get; set; }
        public Nullable<double> Diferencia { get; set; }
        public Nullable<double> DiferenciaCJA { get; set; }
        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
        [StringLength(1)]
        public string Reconteo { get; set; }
    }
    public class zt_inventarios_conteos
    {
        public int IdInventario { get; set; }
       
        [StringLength(20)]
        public string IdSKU { get; set; }
        [StringLength(10)]
        public string IdUnidadMedida { get; set; }
        [StringLength(20)]
        public string IdAlmacen { get; set; }
        
        [StringLength(20)]
        public string IdUbicacion { get; set; }
        public int NumConteo { get; set; }
        
        [StringLength(20)]
        public string CodigoBarras { get; set; }
        
        public Nullable<double> CantidadFisica { get; set; }
        public Nullable<double> CantidadPZA { get; set; }
        [StringLength(30)]
        public string Lote { get; set; }
        public Nullable<DateTime> FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }

    public class zt_inv_conteos_acumulados
    {
        public int IdInventario { get; set; }
        [StringLength(20)]
        public string IdAlmacen { get; set; }
        [StringLength(20)]
        public string IdUbicacion { get; set; }
        [StringLength(20)]
        public string IdUnidadMedida { get; set; }
        [StringLength(20)]
        public string IdSKU { get; set; }
        public int NumConteo { get; set; }
        public Nullable<double> CantidadTeorica { get; set; }
        public Nullable<double> CantidadTeoricaCJA { get; set; }
        public Nullable<double> Diferencia { get; set; }
        public Nullable<double> DiferenciaCJA { get; set; }
        public Nullable<double> CantidadFisica { get; set; }
        public Nullable<double> CantidadFisicaPZA { get; set; }
    }
    public class zt_inv_conteos_acumulados2
    {
        public int IdInventario { get; set; }
        [StringLength(20)]
        public string IdAlmacen { get; set; }
        [StringLength(20)]
        public string IdUbicacion { get; set; }
        [StringLength(20)]
        public string IdUnidadMedida { get; set; }
        [StringLength(20)]
        public string IdSKU { get; set; }
        public int NumConteo { get; set; }
        public Nullable<double> CantidadTeorica { get; set; }
        public Nullable<double> CantidadTeoricaCJA { get; set; }
        public Nullable<double> Diferencia { get; set; }
        public Nullable<double> DiferenciaCJA { get; set; }
        public Nullable<double> CantidadFisica { get; set; }
        public Nullable<double> CantidadFisicaCJA { get; set; }
        public Nullable<double> CantidadPZA { get; set; }
        public string Reconteo { get; set; }
        public string Activo { get; set; }
        public string Borrado { get; set; }
        public Nullable<DateTime> FechaReg { get; set; }
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        public string UsuarioMod { get; set; }
        public string CodigoBarras { get; set; }
        public string Lote { get; set; }
    }

}
