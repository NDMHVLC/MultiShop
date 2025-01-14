﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[AllowAnonymous]
	[Route("Admin/Category")]
	public class CategoryController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public CategoryController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			ViewBag.v0 = " Kategori Sayfası";
			ViewBag.v1 = " Ana Sayfa";
			ViewBag.v2 = " Kategoriler";
			ViewBag.v3 = " Kategori Listesi";

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7070/api/Categories");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
				return View(values);
			}

			return View();
		}
		[Route("CreateCategory")]
		[HttpGet]
		public IActionResult CreateCategory()
		{
			ViewBag.v0 = " Kategori Ekleme Sayfası";
			ViewBag.v1 = " Ana Sayfa";
			ViewBag.v2 = " Kategoriler";
			ViewBag.v3 = " Kategori Ekle";
			return View();
		}
		[Route("CreateCategory")]
		[HttpPost]
		public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createCategoryDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7070/api/Categories", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Category", new { area = "Admin" });
			}
			return View();
		}
		[Route("DeleteCategory/{id}")]
		[HttpDelete]
		public async Task<IActionResult> DeleteCategory(string id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync("https://localhost:7070/api/Categories?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Category", new { area = "Admin" });
			}
			return View();
		}
		[Route("UpdateCategory/{id}")]
		[HttpGet]

		public async Task<IActionResult> UpdateCategory(string id)
		{
			ViewBag.v0 = " Kategori Güncelleme Sayfası";
			ViewBag.v1 = " Ana Sayfa";
			ViewBag.v2 = " Kategoriler";
			ViewBag.v3 = " Kategori Güncelle";
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7070/api/Categories/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
				return View(values);
			}
			return View();
		}

		[Route("UpdateCategory/{id}")]
		[HttpPost]
		public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateCategoryDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7070/api/Categories/", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Category", new { area = "Admin" });
			}
			return View();
		}



		//public async Task<IActionResult> UpdateCategory(string id, UpdateCategoryDto updateCategoryDto)
		//{
		//	var client = _httpClientFactory.CreateClient();
		//	var jsonData = JsonConvert.SerializeObject(updateCategoryDto);
		//	StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
		//	var responseMessage = await client.PutAsync("https://localhost:7070/api/Categories?id=" + id, stringContent);
		//	if (responseMessage.IsSuccessStatusCode)
		//	{
		//		return RedirectToAction("Index", "Category", new { area = "Admin" });
		//	}
		//	return View();
		//}
	}
}
