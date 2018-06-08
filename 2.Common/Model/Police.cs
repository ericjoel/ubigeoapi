using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Common.Model
{
    public class Police : IValidatableObject
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; }

        public Address Address { get; set; }        

        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage ="Start date is required")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Department is required")]
        [StringLength(20, ErrorMessage = "Department exceeds max length (20)")]
        [BsonIgnore]
        public string IdDepartment { get; set; }

        [Required(ErrorMessage = "District is required")]
        [StringLength(100, ErrorMessage = "District exceeds max length (20)")]
        [BsonIgnore]
        public string IdDistrict { get; set; }

        [Required(ErrorMessage = "Province is required")]
        [StringLength(100, ErrorMessage = "Province exceeds max length (20)")]
        [BsonIgnore]
        public string IdProvince { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (StartDate > DateTime.UtcNow.AddHours(-5))
                results.Add(new ValidationResult("The start date must be less than today"));
            
            return results;
        }
    }
}
