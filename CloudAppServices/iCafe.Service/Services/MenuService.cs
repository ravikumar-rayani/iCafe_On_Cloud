using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using iCafe.Model.Models;
using iCafe.Data.Infrastructure;
using iCafe.Repository.Interfaces;
using iCafe.Repository.Classes;
using iCafe.Common.Utilities;
using iCafe.DTO.Client;

namespace iCafe.Service.Services
{
    public class MenuService : IMenuService
    {
        private readonly IItemCategoryRepository itemCategoriesRepository;
        private readonly ITagRepository tagRepository;
        private readonly IItemTagRepository itemTagRepository;
        private readonly IItemRepository itemRepository;
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;

        public MenuService()
        {
            var dbFactory = new DbFactory();    //("iCafe-" + "CompanyCode", "CompanyCode-" + "branchcode");
            this.itemCategoriesRepository = new ItemCategoryRepository(dbFactory);
            this.tagRepository = new TagRepository(dbFactory);
            this.itemRepository = new ItemRepository(dbFactory);
            this.itemTagRepository = new ItemTagRepository(dbFactory);
            this.userRepository = new UserRepository(dbFactory);
            this.unitOfWork = new UnitOfWork(dbFactory);
        }

        #region IMenuService Members

        #region Get Methods

        public IEnumerable<ItemCategory> GetItemCategories()
        {
            var categories = itemCategoriesRepository.GetAll();
            //categories.ToList().ForEach(c => { c.SmallImage = ImageUtilities.ImageToBase64("~/Images/biryani.jpg"); });
            return categories;
        }
        public IEnumerable<Tag> GetTags()
        {
            var tags = tagRepository.GetAll();
            return tags;
        }

        public int[] GetTagsbyItem(int itemId)
        {
            var tags = itemTagRepository.GetAll().Where(t => t.ItemID.Equals(itemId)).Select(i => i.TagID).ToArray();
            return tags;
        }

        public IList<ItemsClientDTO> GetItems()
        { 
            var items = new List<ItemsClientDTO>();
            foreach(var item in itemRepository.GetAll())
            {
                items.Add(new ItemsClientDTO() { 
                    Id = item.Id,
                    Name = item.Name,
                    ItemCategoryId = item.ItemCategoryId,
                    IsAvailable = (bool)item.IsAvailable,
                    Discount = item.Discount,
                    Price = item.Price, 
                    SpicyLevel = item.SpicyLevel,
                    Ingrediants = item.Ingrediants.Trim().Split(',').ToArray(),
                    Tags = GetTagsbyItem(item.Id),
                    Description = item.Description, 
                    SmallImage = item.SmallImage,
                    FullImage = item.FullImage, 
                });
            }            
            return items;
        }
        public IList<ItemsClientDTO> GetItemsByCategoryId(int CategoryId)
        {
            var items = new List<ItemsClientDTO>();
            foreach (var item in itemRepository.GetAll().Where(i => i.ItemCategoryId.Equals(CategoryId)).ToList())
            {
                items.Add(new ItemsClientDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                    ItemCategoryId = item.ItemCategoryId,
                    IsAvailable = (bool)item.IsAvailable,
                    Discount = item.Discount,
                    Price = item.Price,
                    SpicyLevel = item.SpicyLevel,
                    Ingrediants = item.Ingrediants.Trim().Split(',').ToArray(),
                    Tags = GetTagsbyItem(item.Id),
                    Description = item.Description,
                    SmallImage = item.SmallImage,
                    FullImage = item.FullImage,
                });
            }
            return items;
        }
        public IList<ItemsClientDTO> GetItemsByTagId(int TagId)
        {
            var items = new List<ItemsClientDTO>();
            foreach (var item in itemRepository.GetAll().Where(i => GetTagsbyItem(i.Id).Contains(TagId)))
            {
                items.Add(new ItemsClientDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                    ItemCategoryId = item.ItemCategoryId,
                    IsAvailable = (bool)item.IsAvailable,
                    Discount = item.Discount,
                    Price = item.Price,
                    SpicyLevel = item.SpicyLevel,
                    Ingrediants = item.Ingrediants.Trim().Split(',').ToArray(),
                    Tags = GetTagsbyItem(item.Id),
                    Description = item.Description,
                    SmallImage = item.SmallImage,
                    FullImage = item.FullImage,
                });
            }
            return items;
        }
        public IList<ItemsClientDTO> GetItemsByCategoryIdAndTagId(int CategoryId, int TagId)
        {
            var items = new List<ItemsClientDTO>();
            foreach (var item in itemRepository.GetAll().Where(i => i.ItemCategoryId.Equals(CategoryId)
                                                    && GetTagsbyItem(i.Id).Contains(TagId)).ToList())
            {
                items.Add(new ItemsClientDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                    ItemCategoryId = item.ItemCategoryId,
                    IsAvailable = (bool)item.IsAvailable,
                    Discount = item.Discount,
                    Price = item.Price,
                    SpicyLevel = item.SpicyLevel,
                    Ingrediants = item.Ingrediants.Trim().Split(',').ToArray(),
                    Tags = GetTagsbyItem(item.Id),
                    Description = item.Description,
                    SmallImage = item.SmallImage,
                    FullImage = item.FullImage,
                });
            }
            return items;
        }

#endregion

        #region Add Methods

        public void Add(ItemCategory entity)
        {
            itemCategoriesRepository.Add(entity);
        }

        public void Add(Tag tag)
        {
            tagRepository.Add(tag);
        }

        public void Add(ItemTag itemTag)
        {
            itemTagRepository.Add(itemTag);
        }
        
        public void Add(Item item)
        {
            itemRepository.Add(item);
        }

        #endregion

        #region Update Methods

        public void Update(ItemCategory entity)
        {
            itemCategoriesRepository.Update(entity);
        }

        public void Update(Tag tag)
        {
            tagRepository.Update(tag);
        }

        public void Update(ItemTag itemTag)
        {
            itemTagRepository.Update(itemTag);
        }

        public void Update(Item item)
        {
            itemRepository.Update(item);
        }

        #endregion

        #region Delete Methods

        public void DeleteItemCategory(int id)
        {
            itemCategoriesRepository.Delete(id);
        }

        public void DeleteTag(int id)
        {
            tagRepository.Delete(id);
        }

        public void DeleteItemTag(int itemId, int tagId)
        {
            itemTagRepository.Delete(x => x.ItemID == itemId && x.TagID == tagId);
        }

        public void DeleteItem(int id)
        {
            itemRepository.Delete(id);
        }

        #endregion

        public void Save()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}