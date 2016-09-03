using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iCafe.Model.Models;
using iCafe.DTO.Client;
using iCafe.Data;
using iCafe.Data.Infrastructure;
using iCafe.Repository.Interfaces;

namespace iCafe.Service.Services
{
    public interface IMenuService
    {
        #region Get Methods

        IEnumerable<ItemCategory> GetItemCategories();

        IEnumerable<Tag> GetTags();
        
        IList<ItemsClientDTO> GetItems();
        
        //void DeleteItemCategoiesById(int id);

        #endregion
        
        #region Add Methods

        void Add(ItemCategory entity);

        void Add(Tag tag);
        
        void Add(ItemTag itemTag);
        
        void Add(Item item);

        #endregion

        #region Update Methods

        void Update(ItemCategory entity);

        void Update(Tag tag);

        void Update(ItemTag itemTag);

        void Update(Item item);

        #endregion

        #region Delete Methods

        void DeleteItemCategory(int id);

        void DeleteTag(int id);
        
        void DeleteItemTag(int itemId, int tagId);

        void DeleteItem(int id);

        #endregion

        void Save();
    }
}
