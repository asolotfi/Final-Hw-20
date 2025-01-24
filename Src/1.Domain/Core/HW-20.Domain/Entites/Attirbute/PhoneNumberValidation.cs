using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace HW_20.Domain.Entites.Attirbute
{
    public class PhoneNumberValidation:ValidationAttribute
    {
        //[AttributeUsage(AttributeTargets.Property |
        //   AttributeTargets.Field, AllowMultiple = false)]
        public override bool Equals([NotNullWhen(true)] object? obj) => base.Equals(obj);
        public override bool IsValid(Object? valuse)
        {
            if (valuse == null) return false;
            var PhoneNumber=valuse.ToString();
            if(PhoneNumber.StartsWith("98"))  return true;
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
