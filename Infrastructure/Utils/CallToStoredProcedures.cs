namespace Infrastructure.Utils
{
    public static class CallToStoredProcedures
    {
        public static class Plantilla
        {
            public const string GuardarPlantilla = "";
        }

        public static class Empresa
        {
            public const string GetEmpresas = "[par].[SpParametrosIniciales] @Operacion = @Operacion";
            public const string GetListEmpresas = "[par].[Empresas] @Operacion = @Operacion";
            public const string PutEmpresa = "[par].[Empresas] @Operacion = @Operacion, " +
                "@Emp_NombreEmpresa = @Emp_NombreEmpresa, " +
                "@Emp_Direccion = @Emp_Direccion, " +
                "@Emp_Telefono = @Emp_Telefono, " +
                "@Emp_Abreviatura = @Emp_Abreviatura, " +
                "@Emp_Trb_CodTrabajadorRepresentanteLegal = @Emp_Trb_CodTrabajadorRepresentanteLegal, " +
                "@Emp_Nit = @Emp_Nit, " +
                "@Emp_Estado = @Emp_Estado";
            public const string DeleteEmpresa = "[par].[Empresas] @Operacion = @Operacion, @Emp_IdEmpresa = @Emp_IdEmpresa";
            public const string PostCrear = "[par].[Empresas] @Operacion = @Operacion, " +
                "@Emp_NombreEmpresa = @Emp_NombreEmpresa, " +
                "@Emp_Direccion = @Emp_Direccion, " +
                "@Emp_Telefono = @Emp_Telefono, " +
                "@Emp_Abreviatura = @Emp_Abreviatura, " +
                "@Emp_Trb_CodTrabajadorRepresentanteLegal = @Emp_Trb_CodTrabajadorRepresentanteLegal, " +
                "@Emp_Nit = @Emp_Nit, " +
                "@Emp_Estado = @Emp_Estado";
        }

        public static class LogErrores
        {
            public const string SaveError = "[log].[SpLogErrores] @Operacion = @Operacion, " +
                "@Origen = @Origen, " +
                "@Controlador = @Controlador, " +
                "@Funcion = @Funcion, " +
                "@Descripcion = @Descripcion, " +
                "@Usuario = @Usuario";
        }

        public static class Mail
        {
            public const string SendMailMasive = "[conf].[SpGestionMail] @Operacion = @Operacion, " +
                "@To = @To, " +
                "@Cco = @Cco, " +
                "@Asunto = @Asunto, " +
                "@Body = @Body";
        }

        public static class Menu
        {
            public const string GetMenus = "[usr].[SpGetMenu] @Operacion = @Operacion, " +
                "@Men_Tusr_CodTipoUsuario = @Men_Tusr_CodTipoUsuario";
        }

        public static class Notifications
        {
            public const string GetNotificacion = "noti.SpNotifications @Operacion = @Operacion, @notiCodUsario = @notiCodUsario, @onlyActiveNotifications=@onlyActiveNotifications";
            public const string PutNotificacion = "noti.SpNotifications @Operacion = @Operacion, " +
                "@notiIdNotification = @notiIdNotification, @CodUserUpdate = @CodUserUpdate";
        }

        public static class PerfilesXusuario
        {
            public const string GetListado = "[usr].[SpPerfilesXusuario] @Operacion = @Operacion";
            public const string GetPorId = "[usr].[SpPerfilesXusuario] @Operacion = @Operacion, " +
                "@IdPerfilXusuario = @IdPerfilXusuario";
            public const string GetListadoCodUsuarioNotificaciones = "[usr].[SpPerfilesXusuario] @Operacion = @Operacion, @listadoIdsPerfiles = @listadoIdsPerfiles";
            public const string PostCrear = "[usr].[SpPerfilesXusuario] @Operacion = @Operacion, " +
                "@CodUsuario = @CodUsuario, @CodAplicacion = @CodAplicacion, @CodPerfil = @CodPerfil, " +
                "@Estado = @Estado, @CodArchivo = @CodArchivo, @CodUser = @CodUser";
            public const string PutActualizar = "[usr].[SpPerfilesXusuario] @Operacion = @Operacion, " +
                "@IdPerfilXusuario = @IdPerfilXusuario, @CodUsuario = @CodUsuario, @CodAplicacion = @CodAplicacion, " +
                "@CodPerfil = @CodPerfil, @Estado = @Estado, @CodArchivo = @CodArchivo, @CodUserUpdate = @CodUserUpdate";
            public const string DeleteRegistro = "[usr].[SpPerfilesXusuario] @Operacion = @Operacion, " +
                "@IdPerfilXusuario = @IdPerfilXusuario, @CodUserUpdate = @CodUserUpdate";
        }

        public static class Perfil
        {
            public const string GetPerfiles = "[usr].[SpPerfiles] @Operacion = @Operacion";
            public const string GetPerfilesSSR = "[usr].[SpPerfiles] @Operacion = @Operacion, @first = @first, " +
                "@ord = @ord, @SortOrder = @SortOrder, @Total = @Total";
            public const string Getperfil = "[usr].[SpPerfiles] @Operacion = @Operacion, @IdPerfil = @IdPerfil";
            public const string PostCrear = "[usr].[SpPerfiles] @Operacion = @Operacion, @IdPerfil = @IdPerfil, @NombrePerfil = @NombrePerfil, " +
                "@Administrador = @Administrador, @Estado = @Estado, @CodArchivo = @CodArchivo, @CodUser = @CodUser";
            public const string PutActualizar = "[usr].[SpPerfiles] @Operacion = @Operacion, @IdPerfil = @IdPerfil, " +
                "@NombrePerfil = @NombrePerfil, @Administrador = @Administrador, @Estado = @Estado, @CodArchivo = @CodArchivo, " +
                "@CodUserUpdate = @CodUserUpdate";
            public const string DeletePerfil = "[usr].[SpPerfiles] @Operacion = @Operacion, @IdPerfil = @IdPerfil, " +
                "@CodUserUpdate = @CodUserUpdate";
            public const string GetTotalPerfilesSSR = "exec [usr].[SpPerfiles] @Operacion = '7', @contPerfiles = @returnVal output";
            public const string GetperfilesByUserPerfilId = "[usr].[SpPerfiles] @Operacion = @Operacion, @IdPerfil = @IdPerfil";
        }

        public static class PermisosEmpresasxUsuario
        {
            public const string GetListado = "[usr].[SpPermisoEmpresasXusuarios] @Operacion = @Operacion";
            public const string GetPorId = "[usr].[SpPermisoEmpresasXusuarios] @Operacion = @Operacion, @IdPermiso = @IdPermiso";
            public const string PostCrear = "[usr].[SpPermisoEmpresasXusuarios] @Operacion = @Operacion, " +
                "@CodUsuario = @CodUsuario, @cadena = @cadena, @Estado = @Estado, @CodUser = @CodUser, @CodArchivo = @CodArchivo";
            public const string PutActualizar = "[usr].[SpPermisoEmpresasXusuarios] @Operacion = @Operacion, " +
                "@CodUsuario = @CodUsuario, @cadena = @cadena, @Estado = @Estado, @CodUser = @CodUser, @CodArchivo = @CodArchivo";
            public const string DeleteRegistro = "[usr].[SpPermisoEmpresasXusuarios] @Operacion = @Operacion, " +
                "@IdPermiso = @IdPermiso, @CodUserUpdate = @CodUserUpdate";
        }

        public static class PermisosMenuXperfil
        {
            public const string GetListado = "[usr].[SpPermisosMenuXperfil] @Operacion = @Operacion";
            public const string GetPorId = "[usr].[SpPermisosMenuXperfil] @Operacion = @Operacion, @IdPermiso = @IdPermiso";
            public const string PostCrear = "[usr].[SpPermisosMenuXperfil] @Operacion = @Operacion, " +
                "@CodPerfil = @CodPerfil, @CodAplicacion = @CodAplicacion, @CodMenu = @CodMenu, @Ejecutar = @Ejecutar, " +
                "@Leer = @Leer, @Editar = @Editar, @Grabar = @Grabar, @Borrar = @Borrar, @Consultar = @Consultar, " +
                "@CodArchivo = @CodArchivo, @CodUser = @CodUser";
            public const string PutActualizar = "[usr].[SpPermisosMenuXperfil] @Operacion = @Operacion, " +
                "@IdPermiso = @IdPermiso, @CodPerfil = @CodPerfil, @CodAplicacion = @CodAplicacion, @CodMenu = @CodMenu, " +
                "@Ejecutar = @Ejecutar, @Leer = @Leer, @Editar = @Editar, @Grabar = @Grabar, @Borrar = @Borrar, " +
                "@Consultar = @Consultar, @CodArchivo = @CodArchivo, @CodUserUpdate = @CodUserUpdate";
            public const string DeleteRegistro = "[usr].[SpPermisosMenuXperfil] @Operacion = @Operacion, " +
                "@IdPermiso = @IdPermiso, @CodUserUpdate = @CodUserUpdate";
        }

        public static class PermisosUsuarioxMenu
        {
            public const string GetListado = "[usr].[SpPermisosUsuarioXmenu] @Operacion = @Operacion";
            public const string GetPorId = "[usr].[SpPermisosUsuarioXmenu] @Operacion = @Operacion, @IdPermiso = @IdPermiso";
            public const string PostCrear = "[usr].[SpPermisosUsuarioXmenu] @Operacion = @Operacion, @CodUsuario = @CodUsuario, " +
                "@CodAplicacion = @CodAplicacion, @CodMenu = @CodMenu, @Ejecutar = @Ejecutar, @Leer = @Leer, @Editar = @Editar, @Grabar = @Grabar, " +
                "@Borrar = @Borrar, @Consultar = @Consultar, @CodArchivo = @CodArchivo, @CodUser = @CodUser";
            public const string PutActualizar = "[usr].[SpPermisosUsuarioXmenu] @Operacion = @Operacion, @IdPermiso = @IdPermiso, @CodUsuario = @CodUsuario, " +
                "@CodAplicacion = @CodAplicacion, @CodMenu = @CodMenu, @Ejecutar = @Ejecutar, @Leer = @Leer, @Editar = @Editar, @Grabar = @Grabar, " +
                "@Borrar = @Borrar, @Consultar = @Consultar, @CodArchivo = @CodArchivo, @CodUserUpdate = @CodUserUpdate";
            public const string DeleteRegistro = "[usr].[SpPermisosUsuarioXmenu] @Operacion = @Operacion, @IdPermiso = @IdPermiso, @CodUserUpdate = @CodUserUpdate";
            public const string GetPermisosXUsuario = "[usr].[SpPermisosXUsuario] @Operacion = @Operacion, @CodUser = @CodUser";
            public const string GetPermisosXUsuarioController = "[usr].[SpPermisosXUsuario] @Operacion = @Operacion, @CodUser = @CodUser, " +
                "@Men_Controlador = @Men_Controlador";
        }

        public static class Usuario
        {
            public const string GetListarUsuarios = "[usr].[SpUsuario] @Operacion = @Operacion";
            public const string GetUsuarioXCedula = "[usr].[SpUsuario] @Operacion = @Operacion, @Cedula = @Cedula";
            public const string GetUsuarioPorId = "[usr].[SpUsuario] @Operacion = @Operacion, @Id = @Id";
            public const string PostCrearUsuario = "[usr].[SpUsuario] @Operacion = @Operacion, @Cedula = @Cedula, @TipoUsuario = @TipoUsuario, " +
                "@Nombres = @Nombres, @Apellidos = @Apellidos, @Email = @Email, @Password = @Password, @Token = @Token, @EmpresaProceso = @EmpresaProceso, " +
                "@Estado = @Estado, @CodArchivo = @CodArchivo, @CodUser = @CodUser";
            public const string PostCrearUsuarioCliente = "[usr].[SpUsuario] @Operacion = @Operacion, @Cedula = @Cedula, @TipoUsuario = @TipoUsuario, " +
                "@Nombres = @Nombres, @Apellidos = @Apellidos, @Email = @Email, @Password = @Password, @Token = @Token, @EmpresaProceso = @EmpresaProceso, " +
                "@Estado = @Estado, @CodArchivo = @CodArchivo, @CodUser = @CodUser";
            public const string PutActualizarUsuario = "[usr].[SpUsuario] @Operacion = @Operacion, @Id = @Id, @Cedula = @Cedula, @TipoUsuario = @TipoUsuario, " +
                "@Nombres = @Nombres, @Apellidos = @Apellidos, @Email = @Email, @EmpresaProceso = @EmpresaProceso, @Estado = @Estado, " +
                "@CodArchivo = @CodArchivo, @CodUserUpdate = @CodUserUpdate";
            public const string DeleteUsuario = "[usr].[SpUsuario] @Operacion = @Operacion, @Id = @Id, @CodUserUpdate = @CodUserUpdate";
            public const string GetLoginByCredentials = "[usr].[SpUsuario] @Operacion = @Operacion, @Email = @Email";
            public const string CambiarClaveUsuario = "[usr].[SpUsuario] @Operacion = @Operacion, @Id = @Id, @Password = @Password, " +
                "@CodUserUpdate = @CodUserUpdate";
            public const string ResetearClaveUsuario = "[usr].[SpUsuario] @Operacion = @Operacion, @Id = @Id, @Token = @Token, @Password = @Password, " +
                "@CodUserUpdate = @CodUserUpdate";
            public const string PutActualizarEmpresaUsuario = "[usr].[SpUsuario] @Operacion = @Operacion, @Id = @Id, @EmpresaProceso = @EmpresaProceso, " +
                "@CodUserUpdate = @CodUserUpdate";
            public const string ForgottenPassword = "[usr].[SpUsuario] @Operacion = @Operacion, @Cedula = @Cedula, @Email = @Email, @Token = @Token";
            public const string RecoveryPassword = "[usr].[SpUsuario] @Operacion = @Operacion, @Token = @Token, @Password = @Password";
            public const string PutTmpSuspendidoUsuario = "[usr].[SpUsuario] @Operacion = @Operacion, @Token = @Token";
            public const string PutUpdateEstadoUsuario = "[usr].[SpUsuario] @Operacion = @Operacion, @Id = @Id, @Estado = @Estado, @CodUserUpdate = @CodUserUpdate";
        }
    }
}