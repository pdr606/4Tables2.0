using System.ComponentModel.DataAnnotations;

namespace _4Tables2._0.Domain.ProductDomain.Enum
{
    public enum EProductCategory
    {
        [Display(Name = "Espetinho.")]
        meat_skewers = 0,

        [Display(Name = "Bebidas não alcoólicas.")]
        beverager = 1,
    }
}
