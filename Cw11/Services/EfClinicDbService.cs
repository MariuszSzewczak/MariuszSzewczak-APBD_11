using System;
using System.Collections;
using System.Linq;
using Cw11.DTOs;
using Cw11.Models;

namespace Cw11.Services
{
    public class EfClinicDbService: IClinicDbService
    {
        private readonly ClinicDbContext _context;
        public EfClinicDbService(ClinicDbContext context)
        {
            _context = context;
        }

        public IEnumerable GetDoctors()
        {
            return _context.Doctor.ToList();
        }

        public Doctor AddDoctor(AddDoctorRequest request)
        {
            var doctor = _context.Doctor.FirstOrDefault(e => e.IdDoctor == request.IdDoctor);
            if(doctor != null)
                throw new Exception("Doctor is already exists!");
            
            doctor = new Doctor()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };
            _context.Doctor.Add(doctor);
            _context.SaveChanges();
            
            return doctor;
        }

        public Doctor DeleteDoctor(int id)
        {
            var doctor = _context.Doctor.FirstOrDefault(e => e.IdDoctor == id);
            if (doctor == null)
                throw new Exception("Doctor is not exists");

            _context.Remove(doctor);
            _context.SaveChanges();
            return doctor;
        }


        public Doctor ModifyDoctor(ModifyDoctorRequest request)
        {
            var doctor = _context.Doctor.FirstOrDefault(e => e.IdDoctor == request.IdDoctor);
                
            if(doctor==null)
                throw new Exception("Doctor is not exists");

            doctor.IdDoctor = request.IdDoctor;
            doctor.FirstName = request.FirstName;
            doctor.LastName = request.LastName;
            doctor.Email = request.Email;
            
            _context.SaveChanges();

            return doctor;
        }

    }
}