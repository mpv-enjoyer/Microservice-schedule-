﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTable.Models;
using TimeTable.Data;
using TimeTable.Models.Entity;
using System.Data;
using TimeTable.Models.Repository;
using TimeTable.Services;

namespace TimeTable.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LessonController : ControllerBase
    {   
        private readonly ILessonService _lessonService;
        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }


        [HttpGet]
        public JsonResult GetAll()
        {
            
            var result = _lessonService.GetAllLessons();

            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(result));
        }

        [HttpGet]
        public JsonResult GetById(Guid id)
        {
            var result = _lessonService.GetLessonById(id);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }


        [HttpPost]
        public JsonResult Create(Lesson lesson)
        { 
            _lessonService.Add(lesson);
            return new JsonResult(Ok());
        }
         
    }
}
