using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataContext.EntityModels
{
    public partial class  WeatherInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        public virtual DateTime InfoDate { get; set; }
        public virtual int TemperatureC { get; set; }
        public virtual string Summary { get; set; }

        //public int TemperatureF
        //{
        //    get
        //    {
        //        return 32 + (int)(TemperatureC / 0.5556);
        //    }
        //}



    }
}
