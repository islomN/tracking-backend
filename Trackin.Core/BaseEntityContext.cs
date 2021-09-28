using Microsoft.EntityFrameworkCore;

namespace Tracking.Core
{
    public class BaseEntityContext: DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsUseLazyLoading { get; set; }

        protected string ConnectionString { get; set;}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isUseLazyLoading"></param>
        public BaseEntityContext(bool isUseLazyLoading)
        {
            IsUseLazyLoading = isUseLazyLoading;
        }

        public BaseEntityContext()
        {
        }
    }
}