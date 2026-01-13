namespace Infrastructure.Data.Configurations.EEP
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    using Core.Entities.Oracle;

    public class TransforConfiguration : IEntityTypeConfiguration<Transfor>
    {
        public void Configure(EntityTypeBuilder<Transfor> entity)
        {
            entity.HasKey(e => e.Code)
                    .HasName("PRI_KEY_TRANSFOR_CODE");

            entity.ToTable("TRANSFOR");

            entity.Property(e => e.Code)
                .HasMaxLength(32)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("CODE");

            entity.Property(e => e.Address)
                .HasMaxLength(99)
                .IsUnicode(false)
                .HasColumnName("ADDRESS");

            entity.Property(e => e.Assembly)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("ASSEMBLY");

            entity.Property(e => e.B)
                .HasColumnType("NUMBER(8,6)")
                .HasDefaultValueSql("0.0");

            entity.Property(e => e.Calitad)
                .HasPrecision(1)
                .HasColumnName("CALITAD");

            entity.Property(e => e.Caso)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CASO");

            entity.Property(e => e.Clase)
                .HasPrecision(1)
                .HasColumnName("CLASE");

            entity.Property(e => e.Cme)
                .HasColumnType("NUMBER(20,10)")
                .HasColumnName("CME")
                .HasDefaultValueSql("0");

            entity.Property(e => e.Cme12)
                .HasColumnType("NUMBER(20,10)")
                .HasColumnName("CME_12")
                .HasDefaultValueSql("0");

            entity.Property(e => e.Cmp)
                .HasColumnType("NUMBER(20,10)")
                .HasColumnName("CMP")
                .HasDefaultValueSql("0");

            entity.Property(e => e.CodSic)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("COD_SIC");

            entity.Property(e => e.Codebank)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("CODEBANK");

            entity.Property(e => e.Codetaxo)
                .HasMaxLength(32)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("CODETAXO");

            entity.Property(e => e.CodigoSui)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CODIGO_SUI");

            entity.Property(e => e.CodigoSuiNum)
                .HasPrecision(10)
                .HasColumnName("CODIGO_SUI_NUM");

            entity.Property(e => e.Connect)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CONNECT_");

            entity.Property(e => e.Consecu015)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CONSECU015");

            entity.Property(e => e.ControlGa)
                .HasPrecision(1)
                .ValueGeneratedOnAdd()
                .HasColumnName("CONTROL_GA")
                .HasDefaultValueSql("1");

            entity.Property(e => e.Cra)
                .HasColumnType("NUMBER(4,2)")
                .HasColumnName("CRA");

            entity.Property(e => e.CruceSic)
                .HasPrecision(1)
                .HasColumnName("CRUCE_SIC");

            entity.Property(e => e.Culosses)
                .HasColumnType("NUMBER(5,2)")
                .HasColumnName("CULOSSES");

            entity.Property(e => e.Customer0)
                .HasColumnType("NUMBER(12,3)")
                .HasColumnName("CUSTOMER_0")
                .HasDefaultValueSql("0");

            entity.Property(e => e.Customer1)
                .HasColumnType("NUMBER(12,3)")
                .HasColumnName("CUSTOMER_1")
                .HasDefaultValueSql("0");

            entity.Property(e => e.Customer2)
                .HasColumnType("NUMBER(12,3)")
                .HasColumnName("CUSTOMER_2")
                .HasDefaultValueSql("0");

            entity.Property(e => e.Customers)
                .HasColumnType("NUMBER(12,3)")
                .HasColumnName("CUSTOMERS")
                .HasDefaultValueSql("0");

            entity.Property(e => e.DateFab)
                .HasColumnType("DATE")
                .HasColumnName("DATE_FAB");

            entity.Property(e => e.DateInst)
                .HasColumnType("DATE")
                .ValueGeneratedOnAdd()
                .HasColumnName("DATE_INST");

            entity.Property(e => e.DateRem)
                .HasColumnType("DATE")
                .HasColumnName("DATE_REM");

            entity.Property(e => e.DateRet)
                .HasColumnType("DATE")
                .HasColumnName("DATE_RET");

            entity.Property(e => e.Datum)
                .HasPrecision(1)
                .HasColumnName("DATUM");

            entity.Property(e => e.Deleted)
                .HasPrecision(1)
                .ValueGeneratedOnAdd()
                .HasColumnName("DELETED")
                .HasDefaultValueSql("0");

            entity.Property(e => e.Demanda)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("DEMANDA");

            entity.Property(e => e.DepId)
                .HasPrecision(2)
                .HasColumnName("DEP_ID");

            entity.Property(e => e.Descriptio)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTIO");

            entity.Property(e => e.Dpto)
                .HasPrecision(2)
                .HasColumnName("DPTO");

            entity.Property(e => e.Eg)
                .HasColumnType("NUMBER(20,10)")
                .HasColumnName("EG")
                .HasDefaultValueSql("0");

            entity.Property(e => e.Egv)
                .HasColumnType("NUMBER(20,10)")
                .HasColumnName("EGV")
                .HasDefaultValueSql("0");

            entity.Property(e => e.Elnode)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("ELNODE");

            entity.Property(e => e.Eneg)
                .HasColumnType("NUMBER(6,3)")
                .HasColumnName("ENEG");

            entity.Property(e => e.Estado)
                .HasPrecision(1)
                .HasColumnName("ESTADO");

            entity.Property(e => e.Estadop)
                .HasPrecision(1)
                .HasColumnName("ESTADOP");

            entity.Property(e => e.Felosses)
                .HasColumnType("NUMBER(5,2)")
                .HasColumnName("FELOSSES");

            entity.Property(e => e.Flag)
                .HasPrecision(1)
                .HasColumnName("FLAG");

            entity.Property(e => e.Flag5)
                .HasPrecision(1)
                .HasColumnName("FLAG5")
                .HasDefaultValueSql("1");

            entity.Property(e => e.Fparent)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("FPARENT");

            entity.Property(e => e.Fparent2)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("FPARENT2");

            entity.Property(e => e.G)
                .HasColumnType("NUMBER(8,6)")
                .HasDefaultValueSql("0.0");

            entity.Property(e => e.Group)
                .HasPrecision(1)
                .HasColumnName("GROUP_");

            entity.Property(e => e.Grupo)
                .HasPrecision(1)
                .HasColumnName("GRUPO");

            entity.Property(e => e.Grupo015)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("GRUPO015");

            entity.Property(e => e.Health)
                .HasPrecision(1)
                .HasColumnName("HEALTH");

            entity.Property(e => e.Idmercado)
                .HasPrecision(10)
                .HasColumnName("IDMERCADO");

            entity.Property(e => e.Impedance)
                .HasColumnType("NUMBER(5,2)")
                .HasColumnName("IMPEDANCE");

            entity.Property(e => e.Invnumber)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("INVNUMBER");

            entity.Property(e => e.IsBank)
                .HasPrecision(1)
                .HasColumnName("IS_BANK")
                .HasDefaultValueSql("0");

            entity.Property(e => e.Iscri)
                .HasPrecision(1)
                .HasColumnName("ISCRI");

            entity.Property(e => e.Iscrin)
                .HasPrecision(1)
                .HasColumnName("ISCRIN");

            entity.Property(e => e.Iscrinr)
                .HasPrecision(1)
                .HasColumnName("ISCRINR");

            entity.Property(e => e.Islight)
                .HasPrecision(1)
                .HasColumnName("ISLIGHT");

            entity.Property(e => e.Ison)
                .HasPrecision(1)
                .HasColumnName("ISON");

            entity.Property(e => e.Isopen)
                .HasPrecision(1)
                .HasColumnName("ISOPEN");

            entity.Property(e => e.Latitud)
                .HasColumnType("NUMBER(15,8)")
                .HasColumnName("LATITUD");

            entity.Property(e => e.Lifespan)
                .HasPrecision(3)
                .HasColumnName("LIFESPAN");

            entity.Property(e => e.Longitud)
                .HasColumnType("NUMBER(15,8)")
                .HasColumnName("LONGITUD");

            entity.Property(e => e.Ltotal)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("LTOTAL");

            entity.Property(e => e.Lvelnode)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("LVELNODE");

            entity.Property(e => e.Marca)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("MARCA");

            entity.Property(e => e.Metercode)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("METERCODE");

            entity.Property(e => e.MigradoGa)
                .HasPrecision(1)
                .HasColumnName("MIGRADO_GA")
                .HasDefaultValueSql("0 ");

            entity.Property(e => e.Municipio)
                .HasPrecision(10)
                .HasColumnName("MUNICIPIO");

            entity.Property(e => e.Mva1phScc)
                .HasColumnType("NUMBER(6,1)")
                .HasColumnName("MVA1PH_SCC");

            entity.Property(e => e.Mva3phScc)
                .HasColumnType("NUMBER(6,1)")
                .HasColumnName("MVA3PH_SCC");

            entity.Property(e => e.Ncalidad)
                .HasPrecision(1)
                .HasColumnName("NCALIDAD");

            entity.Property(e => e.NumTrfs)
                .HasPrecision(1)
                .HasColumnName("NUM_TRFS");

            entity.Property(e => e.Owner)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("OWNER");

            entity.Property(e => e.Owner1)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("OWNER1");

            entity.Property(e => e.Owner1h)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("OWNER1H");

            entity.Property(e => e.Owner2)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("OWNER2");

            entity.Property(e => e.Ownerh)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("OWNERH");

            entity.Property(e => e.Ownerid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OWNERID");

            entity.Property(e => e.Ownername)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("OWNERNAME");

            entity.Property(e => e.Ownertel)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OWNERTEL");

            entity.Property(e => e.Pcv)
                .HasPrecision(1)
                .HasColumnName("PCV");

            entity.Property(e => e.PendRemunera)
                .HasPrecision(1)
                .HasColumnName("PEND_REMUNERA");

            entity.Property(e => e.Pg)
                .HasColumnType("NUMBER(20,10)")
                .HasColumnName("PG")
                .HasDefaultValueSql("0");

            entity.Property(e => e.Phases)
                .HasPrecision(2)
                .HasColumnName("PHASES");

            entity.Property(e => e.Phnode)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("PHNODE");

            entity.Property(e => e.Picture)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("PICTURE");

            entity.Property(e => e.Poblacion)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("POBLACION");

            entity.Property(e => e.Powerdraw)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("POWERDRAW");

            entity.Property(e => e.Project)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("PROJECT");

            entity.Property(e => e.PromedioMinimoHora)
                .HasColumnType("NUMBER(20,10)")
                .HasColumnName("PROMEDIO_MINIMO_HORA")
                .HasDefaultValueSql("0");

            entity.Property(e => e.PromedioMinimoHora12)
                .HasColumnType("NUMBER(20,10)")
                .HasColumnName("PROMEDIO_MINIMO_HORA_12")
                .HasDefaultValueSql("0");

            entity.Property(e => e.Protocolo)
                .HasPrecision(1)
                .HasColumnName("PROTOCOLO");

            entity.Property(e => e.Prstate)
                .HasPrecision(3)
                .HasColumnName("PRSTATE");

            entity.Property(e => e.R)
                .HasColumnType("NUMBER(8,6)")
                .HasDefaultValueSql("1.0");

            entity.Property(e => e.Rpp)
                .HasColumnType("NUMBER(5,2)")
                .HasColumnName("RPP");

            entity.Property(e => e.Se)
                .HasColumnType("NUMBER(20,10)")
                .HasColumnName("SE")
                .HasDefaultValueSql("0");

            entity.Property(e => e.Se12)
                .HasColumnType("NUMBER(20,10)")
                .HasColumnName("SE_12")
                .HasDefaultValueSql("0");

            entity.Property(e => e.Sequence)
                .HasPrecision(1)
                .HasColumnName("SEQUENCE");

            entity.Property(e => e.Serial)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("SERIAL");

            entity.Property(e => e.Sp)
                .HasColumnType("NUMBER(20,10)")
                .HasColumnName("SP")
                .HasDefaultValueSql("0");

            entity.Property(e => e.Symbol)
                .HasPrecision(3)
                .HasColumnName("SYMBOL");

            entity.Property(e => e.Tfile)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("TFILE");

            entity.Property(e => e.TipoRed)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("TIPO_RED");

            entity.Property(e => e.Tiposub)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TIPOSUB");

            entity.Property(e => e.Trftype)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("TRFTYPE");

            entity.Property(e => e.Type)
                .HasPrecision(1)
                .HasColumnName("TYPE");

            entity.Property(e => e.Uccap14)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("UCCAP14");

            entity.Property(e => e.Uia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UIA");

            entity.Property(e => e.User)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("USER_");

            entity.Property(e => e.Valvula)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("VALVULA");

            entity.Property(e => e.Vsec1)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("VSEC1");

            entity.Property(e => e.Vsec2)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("VSEC2");

            entity.Property(e => e.X).HasColumnType("NUMBER(16,4)");

            entity.Property(e => e.Xmag)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("XMAG");

            entity.Property(e => e.Xoffset)
                .HasColumnType("NUMBER(9,2)")
                .HasColumnName("XOFFSET");

            entity.Property(e => e.Xpos)
                .HasColumnType("NUMBER(9,1)")
                .HasColumnName("XPOS")
                .HasDefaultValueSql("0.0");

            entity.Property(e => e.Xsize)
                .HasPrecision(2)
                .HasColumnName("XSIZE")
                .HasDefaultValueSql("0.0");

            entity.Property(e => e.Y).HasColumnType("NUMBER(16,4)");

            entity.Property(e => e.Ymag)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("YMAG");

            entity.Property(e => e.Yoffset)
                .HasColumnType("NUMBER(9,2)")
                .HasColumnName("YOFFSET");

            entity.Property(e => e.Ypos)
                .HasColumnType("NUMBER(9,1)")
                .HasColumnName("YPOS")
                .HasDefaultValueSql("0.0");

            entity.Property(e => e.Ysize)
                .HasPrecision(2)
                .HasColumnName("YSIZE")
                .HasDefaultValueSql("0.0");

            entity.Property(e => e.Z).HasColumnType("NUMBER(7,1)");

            entity.Property(e => e.Zonae)
                .HasPrecision(4)
                .HasColumnName("ZONAE");

            entity.Property(e => e.Zone)
                .HasPrecision(10)
                .HasColumnName("ZONE");
        }
    }
}
