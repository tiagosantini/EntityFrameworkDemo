using EntityFrameworkDemo.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkDemo.Infra.Modules.DespesaModule
{
    public class DespesaRepositoryEF : IDespesaRepository
    {
        public int InserirNovo(Despesa despesa)
        {
            try
            {
                using (FinancaDbContext db = new FinancaDbContext())
                {
                    db.Despesas.Add(despesa);

                    return db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool EditarRegistro(int id, Despesa registro)
        {
            try
            {
                using (FinancaDbContext db = new FinancaDbContext())
                {
                    var despesa = db.Despesas.Where(x => x.Id == id).FirstOrDefault();

                    if (despesa != null)
                    {
                        despesa.Descricao = registro.Descricao;
                        despesa.Valor = registro.Valor;
                        despesa.TipoDespesa = registro.TipoDespesa;

                        db.Despesas.Update(despesa);

                        db.SaveChanges();
                        
                        return true;
                    }
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ExcluirRegistro(int id)
        {
            try
            {
                using (FinancaDbContext db = new FinancaDbContext())
                {
                    var despesa = db.Despesas.Where(x => x.Id == id).FirstOrDefault();

                    if (despesa != null)
                    {
                        db.Despesas.Remove(despesa);

                        db.SaveChanges();

                        return true;
                    }
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Despesa SelecionarPorId(int id)
        {
            try
            {
                using (FinancaDbContext db = new FinancaDbContext())
                {
                    return db.Despesas.Where(x => x.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Despesa> SelecionarTodos()
        {
            try
            {
                using (FinancaDbContext db = new FinancaDbContext())
                {
                    return db.Despesas.OrderBy(x => x.Id).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
