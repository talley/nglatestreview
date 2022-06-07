﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ngvs2022reviews.data.Entities
{
    [Index("email", Name = "UQ__Users__AB6E6164054E20DF", IsUnique = true)]
    public partial class Users
    {
        [Key]
        public Guid id { get; set; }
        [Required]
        [StringLength(200)]
        public string email { get; set; }
        [Required]
        [StringLength(100)]
        public string password { get; set; }
        public DateTime createdat { get; set; }
        [Required]
        [StringLength(100)]
        public string createdby { get; set; }
        public DateTime? updatedat { get; set; }
        [StringLength(100)]
        public string updatedby { get; set; }
    }
}