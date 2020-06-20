using System;
using System.Collections;
using System.Collections.Generic;

namespace Cw11.Models
{
    public class Prescription
    {
        public int IdPrescription { get; set; }
        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }

        
    }
}