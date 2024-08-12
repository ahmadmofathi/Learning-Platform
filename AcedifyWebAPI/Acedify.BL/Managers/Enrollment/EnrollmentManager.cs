using Acedify.Web.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public class EnrollmentManager : IEnrollmentManager
    {
        private readonly IEnrollmentRepo _enrollmentRepo;

        public EnrollmentManager(IEnrollmentRepo enrollmentRepo)
        {
            _enrollmentRepo = enrollmentRepo;
        }

        public string AddEnrollment(EnrollmentAddDTO enrollment)
        {
            Enrollment newEnrollment = new Enrollment
            {
                Enrollment_ID = Guid.NewGuid().ToString(),
                Payment_Type = enrollment.Payment_Type,
                Payment_Amount = enrollment.Payment_Amount,
                PaymentDate = enrollment.PaymentDate,
                CourseId = enrollment.CourseId,
                StudentId = enrollment.StudentId,
            };
            _enrollmentRepo.AddEnrollment(newEnrollment);
            return newEnrollment.Enrollment_ID;
        }

        public string UpdateEnrollment(EnrollmentDTO enrollment)
        {
            if (enrollment.Enrollment_ID == null)
            {
                return "Enrollment's Id is not found";
            }
            Enrollment enrollmentToUpdate = _enrollmentRepo.GetEnrollmentById(enrollment.Enrollment_ID);
            if (enrollmentToUpdate == null)
            {
                return "Enrollment Not Found";
            }
            enrollmentToUpdate.PaymentDate = enrollment.PaymentDate;
            enrollmentToUpdate.StudentId = enrollment.StudentId;
            enrollmentToUpdate.Payment_Amount = enrollment.Payment_Amount;
            enrollmentToUpdate.Payment_Type = enrollment.Payment_Type;
            enrollmentToUpdate.CourseId = enrollment.CourseId;
            _enrollmentRepo.UpdateEnrollment(enrollmentToUpdate);
            return "Enrollment is Updated Successfully";
        }

        public bool DeleteEnrollment(string enrollmentId)
        {
            if (enrollmentId == null)
            {
                return false;
            }
            var enrollment = _enrollmentRepo.GetEnrollmentById(enrollmentId); if (enrollment == null) { return false; }
            _enrollmentRepo.DeleteEnrollment(enrollment);
            return true;
        }

        public EnrollmentDTO? GetEnrollmentById(string enrollmentId)
        {
            Enrollment dbEnrollment = _enrollmentRepo.GetEnrollmentById(enrollmentId);
            if (dbEnrollment == null)
            {
                return null;
            }
            EnrollmentDTO Enrollment = new EnrollmentDTO
            {
                Enrollment_ID = enrollmentId,
                Payment_Type = dbEnrollment.Payment_Type,
                Payment_Amount = dbEnrollment.Payment_Amount,
                StudentId = dbEnrollment.StudentId,
                PaymentDate = dbEnrollment.PaymentDate,
                CourseId = dbEnrollment.CourseId,
            };
            return Enrollment;
        }

        public IEnumerable<EnrollmentDTO> GetAllEnrollments()
        {
            var enrollments = _enrollmentRepo.GetAllEnrollments();
            var allEnrollments = enrollments.Select(dbEnrollment => new EnrollmentDTO
            {
                Enrollment_ID = dbEnrollment.Enrollment_ID,
                Payment_Type = dbEnrollment.Payment_Type,
                Payment_Amount = dbEnrollment.Payment_Amount,
                StudentId = dbEnrollment.StudentId,
                PaymentDate = dbEnrollment.PaymentDate,
                CourseId = dbEnrollment.CourseId,
            });
            return allEnrollments;
        }
    }
}
