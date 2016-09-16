using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using AttributeRouting;
//using AttributeRouting.Web.Http;
using iCafe.Model.Models;
using iCafe.Service.Services;
using iCafe.DTO.Client;
using iCafe.DTO.Server;
using System.Threading.Tasks;
using System.Web.Http.Description;
using iCafe.Service.ActionFilters;


namespace iCafe.Service.Controllers
{
    [RoutePrefix("api/Menu")]
    public class MenuController : ApiController
    {
        private readonly IMenuService _service;
      
        public MenuController() : this (new MenuService())
        {
        }
        public MenuController(IMenuService service)
        {
            _service = service;
        }

        #region GetApis

        #region GetAll

        [Route("AllItems")]
        public IList<ItemClientDTO> GetItems()
        {
            var items = _service.GetAllItems();
            return items;
        }

        [Route("AllItemCategories")]
        public IEnumerable<ItemCategory> GetItemCategories()
        {
            var categories = _service.GetAllItemCategories();
            return categories;
        }

        [Route("AllTags")]
        public IEnumerable<Tag> GetTags()
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
        public ItemCategory GetItemCategory(int id)
        {
            var category = _service.GetItemCategoryById(id);
            return category;
        }

        [HttpGet]
        [Route("tag/{id}")]
        public Tag GetTag(int id)
        {
            var tag = _service.GetTagById(id);
            return tag;
        }

        #endregion GetById

        #region GetByParentId

        [HttpGet]
        [Route("{categoryid}/items")]
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

        #region Post Apis

        [HttpPost]
        [Route("addItemCategory")]
        public IHttpActionResult PostCategory([FromBody] ItemCategory category)
        {
            _service.Add(category);
            _service.Save();
            return Ok();
        }
        
        [HttpPost]
        [Route("addTag")]
        public IHttpActionResult PostTag([FromBody] Tag tag)
        {
            _service.Add(tag);
            _service.Save();
            return Ok();
        }
        
        [HttpPost]
        [Route("addItemtag")]
        public IHttpActionResult PostItemTag([FromBody] ItemTag itemtag)
        {
            _service.Add(itemtag);
            _service.Save();
            return Ok();
        }

        [HttpPost]
        [Route("addItem")]
        public IHttpActionResult PostItemTag([FromBody] Item item)
        {
            _service.Add(item);
            _service.Save();
            return Ok();
        }

        #endregion

        #region Put Apis

        [HttpPut]
        [Route("updateItemCategory/{id}")]
        public IHttpActionResult PutCategory(int id, [FromBody] ItemCategory category)
        {
            _service.Update(category);
            _service.Save();
            return Ok();
        }

        [HttpPut]
        [Route("updateTag/{id}")]
        public IHttpActionResult PutTag(int id, [FromBody] Tag tag)
        {
            _service.Update(tag);
            _service.Save();
            return Ok();
        }

        [HttpPut]
        [Route("updateItemtag/{itemId}/{tagId}")]
        public IHttpActionResult PutItemTag(int itemId, int tagId, [FromBody] ItemTag itemtag)
        {
            _service.Update(itemtag);
            _service.Save();
            return Ok();
        }

        [HttpPut]
        [Route("updateItem/{id}")]
        public IHttpActionResult PutItem(int id, [FromBody] Item item)
        {
            _service.Update(item);
            _service.Save();
            return Ok();
        }

        #endregion

        #region Delete Apis

        [HttpDelete]
        [Route("deleteItemCategory/{id}")]
        public IHttpActionResult DeleteCategory(int id)
        {
            //System.Diagnostics.Debugger.Break();  
            _service.DeleteItemCategory(id);
            _service.Save();
            return Ok();
        }

        [HttpDelete]
        [Route("deleteTag/{id}")]
        public IHttpActionResult DeleteTag(int id)
        {
            _service.DeleteTag(id);
            _service.Save();
            return Ok();
        }

        [HttpDelete]
        [Route("deleItemtag/{itemId}/{tagId}")]
        public IHttpActionResult DeleteItemTag(int itemId, int tagId)
        {
            _service.DeleteItemTag(itemId, tagId);
            _service.Save();
            return Ok();
        }

        [HttpDelete]
        [Route("deleteItem/{id}")]
        public IHttpActionResult DeleteItem(int id)
        {
            _service.DeleteItem(id);
            _service.Save();
            return Ok();
        }

        #endregion
    }
}
