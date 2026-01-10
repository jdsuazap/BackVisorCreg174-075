using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.QueryStrings.SQLContext
{
    internal static class SolConexionAutogenComentarioQuery
    {
        internal static string GetEntities_ByRequesto = @"
            SELECT   c.[IdSolConexionAutogenComentario] AS Id 
                    ,c.* 
                    ,u.[Usr_IdUsuario] AS Id
                    ,u.[Usr_Cedula] AS UsrCedula
                    ,u.[Usr_Tusr_CodTipoUsuario] AS UsrTusrCodTipoUsuario
                    ,u.[Usr_Nombres] AS UsrNombres
                    ,u.[Usr_Apellidos] AS UsrApellidos
                    ,u.[Usr_Email] AS UsrEmail
                    ,u.[Usr_Password] AS UsrPassword
                    ,u.[Usr_EmpresaProceso] AS UsrEmpresaProceso
                    ,u.[Usr_TmpSuspendido] AS UsrTmpSuspendido
                    ,u.[Usr_ForcePasswordChange] AS UsrForcePasswordChange
                    ,u.[Usr_Estado] AS UsrEstado
                    ,u.[Usr_UltimaFechaPassword] AS UsrUltimaFechaPassword
                    ,u.[CodArchivo]
                    ,u.[CodUser]
                    ,u.[FechaRegistro]
                    ,u.[CodUserUpdate]
                    ,u.[FechaRegistroUpdate]
                    ,u.[Info]
                    ,u.[InfoUpdate]
                    ,ISNULL(p.Prf_IdPerfil,-1) AS Id
                    ,p.[Prf_NombrePerfil] AS PrfNombrePerfil
                    ,p.[Prf_Administrador] AS PrfAdministrador
                    ,p.[Prf_Estado] AS PrfEstado
                    ,p.[CodArchivo]
                    ,p.[CodUser]
                    ,p.[FechaRegistro]
                    ,p.[CodUserUpdate]
                    ,p.[FechaRegistroUpdate]
                    ,p.[Info]
                    ,p.[InfoUpdate]
                    ,ca.[IdSolConexionAutogenComentarioAnexos] as Id
                    ,ca.*
            FROM [sol].[SolConexionAutogenComentario] c 
            LEFT JOIN [usr].[Usuario] u ON u.[Usr_IdUsuario] = c.[CodUsuario] 
            LEFT JOIN [usr].[Perfil] p ON p.Prf_IdPerfil = c.CodPerfil 
            LEFT JOIN [sol].[SolConexionAutogenComentarioAnexos] ca ON c.IdSolConexionAutogenComentario =ca.CodSolConexionAutogenComentario	
            WHERE   (c.[CodSolConexionAutogen] = {IdSolConexionAutogenComentario})  AND 
                    (c.CodSolConexionAutogenComentario IS NULL)                     AND 
                    (
                        c.CodUsuario = {codUser}                                                                                       OR 
                        c.CodPerfil IN (SELECT Pxu_Prf_CodPerfil FROM [usr].[PerfilesXUsuarios] WHERE Pxu_Usr_CodUsuario = {codUser})  OR 
                        (c.CodUsuario != {codUser} AND c.CodPerfil IS NULL)                                                            OR 
                        (c.CodPerfil = {idPerilUsuarioCliente} AND c.CodUsuario != {codUser})
                    )
        ";

        internal static string GetEntities_ByComment = @"
            SELECT c.[IdSolConexionAutogenComentario] AS Id 
                ,c.* 
                ,u.[Usr_IdUsuario] AS Id
                ,u.[Usr_Cedula] AS UsrCedula
                ,u.[Usr_Tusr_CodTipoUsuario] AS UsrTusrCodTipoUsuario
                ,u.[Usr_Nombres] AS UsrNombres
                ,u.[Usr_Apellidos] AS UsrApellidos
                ,u.[Usr_Email] AS UsrEmail
                ,u.[Usr_Password] AS UsrPassword
                ,u.[Usr_EmpresaProceso] AS UsrEmpresaProceso
                ,u.[Usr_TmpSuspendido] AS UsrTmpSuspendido
                ,u.[Usr_ForcePasswordChange] AS UsrForcePasswordChange
                ,u.[Usr_Estado] AS UsrEstado
                ,u.[Usr_UltimaFechaPassword] AS UsrUltimaFechaPassword
                ,u.[CodArchivo]
                ,u.[CodUser]
                ,u.[FechaRegistro]
                ,u.[CodUserUpdate]
                ,u.[FechaRegistroUpdate]
                ,u.[Info]
                ,u.[InfoUpdate]
                ,ISNULL(p.Prf_IdPerfil,-1) AS Id
                ,p.[Prf_NombrePerfil] AS PrfNombrePerfil
                ,p.[Prf_Administrador] AS PrfAdministrador
                ,p.[Prf_Estado] AS PrfEstado
                ,p.[CodArchivo]
                ,p.[CodUser]
                ,p.[FechaRegistro]
                ,p.[CodUserUpdate]
                ,p.[FechaRegistroUpdate]
                ,p.[Info]
                ,p.[InfoUpdate]
                ,ca.[IdSolConexionAutogenComentarioAnexos] as Id
                ,ca.*
            FROM [sol].[SolConexionAutogenComentario] c
            LEFT JOIN [usr].[Usuario] u ON u.[Usr_IdUsuario] = c.[CodUsuario]
            LEFT JOIN [usr].[Perfil] p ON p.Prf_IdPerfil = c.CodPerfil
            LEFT JOIN [sol].[SolConexionAutogenComentarioAnexos] ca ON c.IdSolConexionAutogenComentario =ca.CodSolConexionAutogenComentario	
            WHERE c.CodSolConexionAutogenComentario = {codSolConexionAutogenComentario}
        ";
    }
}
