using EstaparGarage.Bussinees.Models;


namespace EstaparGarage.Bussinees.Interfaces
{
    public interface IGaragemRepository : IRepository<Garagem>
    {
        Task<Garagem> ObterGaragemPorCodigo(string codigo);

        Task<Garagem> ObterGaragemPorNome(string nome);


    }
}
