
using Abp.Runtime.Validation;
using Et.Yhy.Dtos;
using Et.Yhy.BuMens;

namespace Et.Yhy.BuMens.Dtos
{
    public class GetBumensInput : PagedSortedAndFilteredInputDto, IShouldNormalize
    {

        /// <summary>
        /// 正常化排序使用
        /// </summary>
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }

    }
}
