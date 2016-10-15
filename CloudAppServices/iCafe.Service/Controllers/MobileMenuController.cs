using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using AttributeRouting;
//using AttributeRouting.Web.Http;
using iCafe.Entity;
using iCafe.Service.Services.Mobile;
using iCafe.DTO.Client;
using iCafe.DTO.Server;
using System.Threading.Tasks;
using System.Web.Http.Description;
using iCafe.Service.ActionFilters;


namespace iCafe.Service.Controllers
{
    [RoutePrefix("api/Mobile/Menu")]
    public class MobileMenuController : ApiController
    {
        private readonly IMenuService _service;
      
        public MobileMenuController() : this (new MenuService())
        {
        }
        public MobileMenuController(IMenuService service)
        {
            _service = service;
        }

        #region GetApis

        #region GetAll

        [ResponseType(typeof(IEnumerable<ItemClientDTO>))]
        [Route("AllItems")]
        [Route("Items")]
        public async Task<IHttpActionResult> GetItems()
        {
            var items = await _service.GetAllItems();
            if (items == null)
            {
                return NotFound();
            }

            return Ok(items);
        }

        [Route("AllItemCategories")]
        public IEnumerable<ItemCategoryClientDTO> GetItemCategories()
        {
            var categories = _service.GetAllItemCategories();
            return categories;
        }

        [Route("AllTags")]
        public IEnumerable<TagClientDTO> GetTags()
        {
            var tags = _service.GetAllTags();

            return tags;
        }

        #endregion GetAll

        #region GetById

        [HttpGet]
        [Route("Item/{id}")]
        public ItemClientDTO GetItem(int id)
        {
            var item = _service.GetItemById(id);
            return item;
        }

        [HttpGet]
        [Route("Category/{id}")]
        public ItemCategoryClientDTO GetItemCategory(int id)
        {
            var category = _service.GetItemCategoryById(id);
            return category;
        }

        [HttpGet]
        [Route("tag/{id}")]
        public TagClientDTO GetTag(int id)
        {
            var tag = _service.GetTagById(id);
            return tag;
        }

        #endregion GetById

        #region GetByParentId

        [HttpGet]
        [Route("{categoryid}/Items")]
        public IList<ItemClientDTO> GetItemsByCategory(int categoryid)
        {
            var items = _service.GetItemsByCategoryId(categoryid);
            return items;
        }

        [HttpGet]
        [Route("{tagid}/Items")]
        public IEnumerable<ItemClientDTO> GetItemsByTag(int tagid)
        {
            var categories = _service.GetItemsByTagId(tagid);
            return categories;
        }

        [HttpGet]
        [Route("{categoryid}/{tagid}/Items")]
        public IEnumerable<ItemClientDTO> GetItemsByCategoryAndTag(int categoryid, int tagid)
        {
            var categories = _service.GetItemsByCategoryIdAndTagId(categoryid, tagid);
            return categories;
        }

        [HttpGet]
        [Route("{categoryid}/tags")]
        public int[] GetTagsByCategory(int categoryid)
        {
            var tags = _service.GetTagsbyItem(categoryid);
            return tags;
        }

        [HttpGet]
        [Route("{itemid}/tags")]
        public int[] GetTagsByItem(int itemid)
        {
            var tags = _service.GetTagsbyItem(itemid);
            return tags;
        }

        #endregion GetByParentId

        #endregion
    }
}
