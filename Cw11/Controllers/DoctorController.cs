using System;
using Cw11.DTOs;
using Cw11.Models;
using Cw11.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cw11.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorController: ControllerBase
    {
        private readonly IClinicDbService _context;
        
        public DoctorController(IClinicDbService context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(_context.GetDoctors());
        }

        [HttpPost("add")]
        public IActionResult AddDoctor(AddDoctorRequest request)
        {
            try
            {
                Doctor doctor = _context.AddDoctor(request);
                return Ok(doctor);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost("update")]
        public IActionResult ModifyDoctor(ModifyDoctorRequest request)
        {
            try
            {
                Doctor doctor = _context.ModifyDoctor(request);
                return Ok(doctor);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            try
            {
                Doctor doctor = _context.DeleteDoctor(id);
                return Ok(doctor);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}