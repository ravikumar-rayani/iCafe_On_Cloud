using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iCafe.Entity;
using iCafe.DTO.Client;
using iCafe.Data;
using iCafe.Data.Infrastructure;
using iCafe.Repository.Interfaces;

namespace iCafe.Service.Services.Mobile
{
    public interface IMenuService
    {
        #region Get Methods

        IEnumerable<ItemCategoryClientDTO> GetAllItemCategories();

        ItemCategoryClientDTO GetItemCategoryById(int CategoryId);

        IEnumerable<TagClientDTO> GetAllTags();

        TagClientDTO GetTagById(int tagId);
        
        Task<IList<ItemClientDTO>> GetAllItems();

        ItemClientDTO GetItemById(int itemId);

        IList<ItemClientDTO> GetItemsByCategoryId(int CategoryId);

        IList<ItemClientDTO> GetItemsByTagId(int TagId);

        IList<ItemClientDTO> GetItemsByCategoryIdAndTagId(int CategoryId, int TagId);

        IList<ItemTagsClientDTO> GetAllItemTags();

           int[] GetTagsbyItem(int itemId);

        #endregion

        void Save();
    }
}
