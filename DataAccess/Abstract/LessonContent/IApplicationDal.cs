﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.DTOs;
using Entities.LessonContent;

namespace DataAccess.Abstract.LessonContent
{
    public interface IApplicationDal:IEntityRepository<Application>
    {
        ApplicationDetailsDto GetApplicationDetails(int applicationId);
    }
}
