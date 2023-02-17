using MvcCoreCrudDepartamentosEF.Data;
using MvcCoreCrudDepartamentosEF.Models;

namespace MvcCoreCrudDepartamentosEF.Repositories
{
    public class RepositoryDepartamentos
    {
        private DepartamentosContext context;

        public RepositoryDepartamentos(DepartamentosContext context)
        {
            this.context = context;
        }

        public List<Departamento> GetDepartamentos()
        {
            var consulta = from datos in this.context.Departamentos
                           select datos;
            return consulta.ToList();
        }

        public Departamento FindDepartamento(int iddepartamento)
        {
            var consulta = from datos in this.context.Departamentos
                           where datos.IdDepartamento == iddepartamento
                           select datos;
            return consulta.FirstOrDefault();
        }

        //METODO PARA CREAR UN DEPARTAMENTO
        //LAS CONSULTAS DE ACCION PUEDEN SER ASINCRONAS
        public async Task InsertDepartamentoAsync
            (int id, string nombre, string localidad)
        {
            //INSTANCIAR EL MODELO
            Departamento departamento = new Departamento();
            //ASIGNAMOS PROPIEDADES
            departamento.IdDepartamento = id;
            departamento.Nombre = nombre;
            departamento.Localidad = localidad;
            //AÑADIMOS EL MODEL A LA COLECCION CONTEXT
            this.context.Departamentos.Add(departamento);
            //GUARDAMOS CAMBIOS EN LA BASE DE DATOS
            await this.context.SaveChangesAsync();
        }

        //METODO PARA MODIFICAR DEPARTAMENTO
        public async Task UpdateDepartamentoAsync
            (int id, string nombre, string localidad)
        {
            //BUSCAMOS EL MODEL DENTRO DEL CONTEXT
            Departamento departamento = this.FindDepartamento(id);
            //MODIFICAMOS SUS PROPIEDADES
            departamento.Nombre = nombre;
            departamento.Localidad = localidad;
            //GUARDAMOS CAMBIOS EN LA BASE DE DATOS
            await this.context.SaveChangesAsync();
        }

        //METODO PARA ELIMINAR DEPARTAMENTO
        public async Task DeleteDepartamentoAsync(int id)
        {
            //BUSCAMOS EL MODEL DENTRO DEL CONTEXT
            Departamento departamento = this.FindDepartamento(id);
            //BORRAMOS EL DEPARTAMENTO DE LA COLECCION DE CONTEXT
            this.context.Departamentos.Remove(departamento);
            //GUARDAMOS CAMBIOS EN LA BASE DE DATOS
            await this.context.SaveChangesAsync();
        }
    }
}
