
using Abp.Runtime.Validation;
using Et.Yhy.Dtos;
using Et.Yhy.Complay;

namespace Et.Yhy.Complay.Dtos
{
    public class GetComplayssInput : PagedSortedAndFilteredInputDto, IShouldNormalize
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
