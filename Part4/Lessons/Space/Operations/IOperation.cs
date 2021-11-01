using System.Threading.Tasks;

namespace Space.Operations

{
    public interface IOperation
    {
        Task DoOperationAsync(); 
    }
}
