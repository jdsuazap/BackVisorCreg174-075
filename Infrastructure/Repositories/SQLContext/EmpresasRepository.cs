using Core.Entities.SQLContext;
using Core.Exceptions;
using Core.Interfaces.SQLContext;
using Core.ModelResponse;
using Infrastructure.Data;
using Infrastructure.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.SQLContext
{
    public class EmpresasRepository : BaseRepository<Empresa>, IEmpresasRepository
    {
        public EmpresasRepository(DbSQLContext context) : base(context) { }

        public async Task<List<Empresa>> GetEmpresas()
        {
            try
            {
                SqlParameter[] parameters = new[] {
                    new SqlParameter("@Operacion","3")
                };

                string sql = CallToStoredProcedures.Empresa.GetEmpresas;
                var response = await _context.Empresas.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;
            }
            catch (Exception e)
            {
                throw new BusinessException($"Error: {e.Message}");
            }
        }

        public async Task<List<Empresa>> GetListEmpresas()
        {
            try
            {
                SqlParameter[] parameters = new[] {
                    new SqlParameter("@Operacion","1")
                };

                string sql = CallToStoredProcedures.Empresa.GetListEmpresas;
                var response = await _context.Empresas.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;
            }
            catch (Exception e)
            {
                throw new BusinessException($"Error: {e.Message}");
            }
        }

        public async Task<List<ResponseAction>> PutEmpresa(Empresa empresa)
        {
            try
            {
                SqlParameter[] parameters = new[] {
                    new SqlParameter("@Operacion","3"),
                    new SqlParameter("@Emp_NombreEmpresa", empresa.EmpNombreEmpresa),
                    new SqlParameter("@Emp_Direccion", empresa.EmpDireccion),
                    new SqlParameter("@Emp_Telefono", empresa.EmpTelefono),
                    new SqlParameter("@Emp_Abreviatura", empresa.EmpAbreviatura),
                    new SqlParameter("@Emp_Trb_CodTrabajadorRepresentanteLegal", empresa.EmpTrbCodTrabajadorRepresentanteLegal),
                    new SqlParameter("@Emp_Nit", empresa.EmpNit),
                    new SqlParameter("@Emp_Estado", empresa.EmpEstado),
             };

                string sql = CallToStoredProcedures.Empresa.PutEmpresa;
                var response = await _context.ResponseActions.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;
            }
            catch (Exception e)
            {
                throw new BusinessException($"Error: {e.Message}");
            }
        }

        public async Task<List<ResponseAction>> DeleteEmpresa(Empresa empresa)
        {
            try
            {
                SqlParameter[] parameters = new[] {
                    new SqlParameter("@Operacion","3"),
                    new SqlParameter("@Emp_IdEmpresa", empresa.Id),
                };

                string sql = CallToStoredProcedures.Empresa.DeleteEmpresa;
                var response = await _context.ResponseActions.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;
            }
            catch (Exception e)
            {
                throw new BusinessException($"Error: {e.Message}");
            }
        }

        public async Task<List<ResponseAction>> PostCrear(Empresa empresa)
        {
            try
            {
                SqlParameter[] parameters = new[] {
                    new SqlParameter("@Operacion","3"),
                    new SqlParameter("@Emp_NombreEmpresa", empresa.EmpNombreEmpresa),
                    new SqlParameter("@Emp_Direccion", empresa.EmpDireccion),
                    new SqlParameter("@Emp_Telefono", empresa.EmpTelefono),
                    new SqlParameter("@Emp_Abreviatura", empresa.EmpAbreviatura),
                    new SqlParameter("@Emp_Trb_CodTrabajadorRepresentanteLegal", empresa.EmpTrbCodTrabajadorRepresentanteLegal),
                    new SqlParameter("@Emp_Nit", empresa.EmpNit),
                    new SqlParameter("@Emp_Estado", empresa.EmpEstado),
                };

                string sql = CallToStoredProcedures.Empresa.PostCrear;
                var response = await _context.ResponseActions.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;
            }
            catch (Exception e)
            {
                throw new BusinessException($"Error: {e.Message}");
            }
        }
    }
}
