using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.QueryStrings.SQLContext
{
    internal class SolConexionAutogenXProrrogaQuery
    {
        internal static string GetGarantiaByProrroga= @"
            SELECT 
                    pg.IdSolConexionAutogenXProrrogaGarantia			AS Id, pg.*, 
	                pga.IdSolConexionAutogenXProrrogaGarantiaAnexos AS Id, pga.*
            FROM sol.SolConexionAutogenXProrrogaGarantia pg (NOLOCK) 
            LEFT JOIN sol.SolConexionAutogenXProrrogaGarantiaAnexos pga (NOLOCK) ON pg.IdSolConexionAutogenXProrrogaGarantia = pga.CodSolConexionAutogenXProrrogaGarantia AND pga.EstadoDocumento = 1
            WHERE pg.CodSolConexionAutogenXProrroga = @IdProrroga AND pg.Estado = 1;
        ";

        internal static string GetProrrogaBySolicitud = @"
             SELECT p.IdSolConexionAutogenXProrroga AS Id, p.*,
                    pg.IdSolConexionAutogenXProrrogaGarantia			AS Id, pg.*, 
                    pga.IdSolConexionAutogenXProrrogaGarantiaAnexos AS Id, pga.*
            FROM sol.SolConexionAutogenXProrroga p (NOLOCK)
            LEFT JOIN sol.SolConexionAutogenXProrrogaGarantia pg (NOLOCK) ON p.IdSolConexionAutogenXProrroga = pg.CodSolConexionAutogenXProrroga AND pg.Estado = 1
            LEFT JOIN sol.SolConexionAutogenXProrrogaGarantiaAnexos pga (NOLOCK) ON pg.IdSolConexionAutogenXProrrogaGarantia = pga.CodSolConexionAutogenXProrrogaGarantia AND pga.EstadoDocumento = 1
            WHERE p.CodSolConexionAutogen = @IdSolicitud;
        ";
    }
}
