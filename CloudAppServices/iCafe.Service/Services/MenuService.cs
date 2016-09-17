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
        private readonly IItemCategoriesAvailablityRepository itemCategoriesAvailablityRepository;
        private readonly ITagRepository tagRepository;
        private readonly ITagsAvailablityRepository tagsAvailablityRepository;
        private readonly IItemTagRepository itemTagRepository;
        private readonly IItemRepository itemRepository;
        private readonly IItemsAvailablityRepository itemsAvailablityRepository;
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;

        public MenuService()
        {
            var dbFactory = new DbFactory();    //("iCafe-" + "CompanyCode", "CompanyCode-" + "branchcode");
            this.itemCategoriesRepository = new ItemCategoryRepository(dbFactory);
            this.itemCategoriesAvailablityRepository = new ItemCategoriesAvailablityRepository(dbFactory);
            this.tagRepository = new TagRepository(dbFactory);
            this.tagsAvailablityRepository = new TagsAvailablityRepository(dbFactory);
            this.itemRepository = new ItemRepository(dbFactory);
            this.itemsAvailablityRepository = new ItemsAvailablityRepository(dbFactory);
            this.itemTagRepository = new ItemTagRepository(dbFactory);
            this.userRepository = new UserRepository(dbFactory);
            this.unitOfWork = new UnitOfWork(dbFactory);
        }

        #region IMenuService Members

        #region Get Methods

        public IEnumerable<ItemCategoryClientDTO> GetAllItemCategories()
        {
            var itemCategories = new List<ItemCategoryClientDTO>();
            var itemCategoryAvailablity = itemCategoriesAvailablityRepository.GetAll();
            foreach (var itemCategory in itemCategoriesRepository.GetAll())
            {
                itemCategories.Add(new ItemCategoryClientDTO()
                {
                    Id = itemCategory.Id,
                    Name = itemCategory.Name,
                    IsAvailable = (bool)itemCategoryAvailablity.Where(i => i.ItemCategoryId.Equals(itemCategory.Id)).Select(p => p.IsAvailable).First(),
                    Discount = itemCategory.Discount,
                    Description = itemCategory.Description,
                    ImageUrl = itemCategory.ImageUrl,
                });
            }
            return itemCategories;
        }

        public ItemCategoryClientDTO GetItemCategoryById(int categoryId)
        {
            var itemCategory = itemCategoriesRepository.GetById(categoryId);
            ItemCategoryClientDTO _itemCategory = new ItemCategoryClientDTO()
            {
                Id = itemCategory.Id,
                Name = itemCategory.Name,
                IsAvailable = (bool) itemCategoriesAvailablityRepository.GetAll().Where(i => i.ItemCategoryId.Equals(categoryId)).Select(p => p.IsAvailable).First(),
                Discount = itemCategory.Discount,
                Description = itemCategory.Description,
                ImageUrl = itemCategory.ImageUrl,
            };
            return _itemCategory;
        }

        public IEnumerable<TagClientDTO> GetAllTags()
        {
            var tags = tagRepository.GetAll();
            var allTags = new List<TagClientDTO>();
            foreach (var tag in tagRepository.GetAll().Where(i =>
                                    tagsAvailablityRepository.GetAll().First(a => a.TagId.Equals(i.Id)).IsAvailable).ToList())
            {
                allTags.Add(new TagClientDTO()
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    Description = tag.Comments 
                });
            }
            return allTags;
        }

        public TagClientDTO GetTagById(int tagId)
        {
            var tag = tagRepository.GetById(tagId);
            TagClientDTO _tag = new TagClientDTO()
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    Description = tag.Comments
                };
            return _tag;
        }

        public IList<ItemClientDTO> GetAllItems()
        { 
            var items = new List<ItemClientDTO>();
            foreach(var item in itemRepository.GetAll())
            {
                items.Add(new ItemClientDTO() { 
                    Id = item.Id,
                    Name = item.Name,
                    ItemCategoryId = item.ItemCategoryId,
                    IsAvailable = (bool)itemsAvailablityRepository.GetAll()
                                    .Where(i => i.ItemId.Equals(item.Id)).Select(p => p.IsAvailable).First(),
                    Discount = item.Discount,
                    Price = item.Price, 
                    SpicyLevel = item.SpicyLevel,
                    Ingrediants = item.Ingrediants.Trim().Split(',').ToArray(),
                    Tags = GetTagsbyItem(item.Id),
                    Description = item.Description, 
                    SmallImage = item.SmallImageUrl,
                    FullImage = item.FullImageUrl, 
                });
            }            
            return items;
        }

        public ItemClientDTO GetItemById(int itemId)
        {
            var item = itemRepository.GetById(itemId);
            ItemClientDTO _item = new ItemClientDTO()
            {
                Id = item.Id,
                Name = item.Name,
                ItemCategoryId = item.ItemCategoryId,
                IsAvailable = (bool)itemsAvailablityRepository.GetAll()
                                .Where(i => i.ItemId.Equals(item.Id)).Select(p => p.IsAvailable).First(),
                Discount = item.Discount,
                Price = item.Price,
                SpicyLevel = item.SpicyLevel,
                Ingrediants = item.Ingrediants.Trim().Split(',').ToArray(),
                Tags = GetTagsbyItem(item.Id),
                Description = item.Description,
                SmallImage = item.SmallImageUrl,
                FullImage = item.FullImageUrl,
            };
            return _item;
        }

        public IList<ItemClientDTO> GetItemsByCategoryId(int CategoryId)
        {
            var items = new List<ItemClientDTO>();
            foreach (var item in itemRepository.GetAll().Where(i => i.ItemCategoryId.Equals(CategoryId)).ToList())
            {
                items.Add(new ItemClientDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                    ItemCategoryId = item.ItemCategoryId,
                    IsAvailable = (bool) itemsAvailablityRepository.GetAll()
                                    .Where(i => i.ItemId.Equals(item.Id)).Select(p => p.IsAvailable).First(),
                    Discount = item.Discount,
                    Price = item.Price,
                    SpicyLevel = item.SpicyLevel,
                    Ingrediants = item.Ingrediants.Trim().Split(',').ToArray(),
                    Tags = GetTagsbyItem(item.Id),
                    Description = item.Description,
                    SmallImage = item.SmallImageUrl,
                    FullImage = item.FullImageUrl,
                });
            }
            return items;
        }

        public IList<ItemClientDTO> GetItemsByTagId(int TagId)
        {
            var items = new List<ItemClientDTO>();
            foreach (var item in itemRepository.GetAll().Where(i => GetTagsbyItem(i.Id).Contains(TagId)))
            {
                items.Add(new ItemClientDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                    ItemCategoryId = item.ItemCategoryId,
                    IsAvailable = (bool)itemsAvailablityRepository.GetAll()
                                    .Where(i => i.ItemId.Equals(item.Id)).Select(p => p.IsAvailable).First(),
                    Discount = item.Discount,
                    Price = item.Price,
                    SpicyLevel = item.SpicyLevel,
                    Ingrediants = item.Ingrediants.Trim().Split(',').ToArray(),
                    Tags = GetTagsbyItem(item.Id),
                    Description = item.Description,
                    SmallImage = item.SmallImageUrl,
                    FullImage = item.FullImageUrl,
                });
            }
            return items;
        }
        
        public IList<ItemClientDTO> GetItemsByCategoryIdAndTagId(int CategoryId, int TagId)
        {
            var items = new List<ItemClientDTO>();
            foreach (var item in itemRepository.GetAll().Where(i => i.ItemCategoryId.Equals(CategoryId)
                                                    && GetTagsbyItem(i.Id).Contains(TagId)).ToList())
            {
                items.Add(new ItemClientDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                    ItemCategoryId = item.ItemCategoryId,
                    IsAvailable = (bool)itemsAvailablityRepository.GetAll()
                                    .Where(i => i.ItemId.Equals(item.Id)).Select(p => p.IsAvailable).First(),
                    Discount = item.Discount,
                    Price = item.Price,
                    SpicyLevel = item.SpicyLevel,
                    Ingrediants = item.Ingrediants.Trim().Split(',').ToArray(),
                    Tags = GetTagsbyItem(item.Id),
                    Description = item.Description,
                    SmallImage = item.SmallImageUrl,
                    FullImage = item.FullImageUrl,
                });
            }
            return items;
        }

        public IList<ItemTagsClientDTO> GetAllItemTags()
        {
            var allitemTags = new List<ItemTagsClientDTO>();
            foreach (var itemtag in itemTagRepository.GetAll().Where(i =>
                                    tagsAvailablityRepository.GetAll().First(a => a.TagId.Equals(i.TagID)).IsAvailable &&
                                    itemsAvailablityRepository.GetAll().First(a => a.ItemId.Equals(i.ItemID)).IsAvailable).ToList())
            {
                allitemTags.Add(new ItemTagsClientDTO()
                {
                    ItemID = itemtag.ItemID,
                    TagID = itemtag.TagID,
                });
            }
            return allitemTags;
        }
        
        public int[] GetTagsbyItem(int itemId)
        {

            var tags = itemTagRepository.GetAll().Where(t => t.ItemID.Equals(itemId) && 
                        tagsAvailablityRepository.GetAll().First( a => a.TagId.Equals(t.TagID)).IsAvailable).Select(i => i.TagID).ToArray();
            
            return tags;
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