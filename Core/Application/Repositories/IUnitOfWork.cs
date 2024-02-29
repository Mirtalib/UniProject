using Application.Repositories.IDepartmentRepository;
using Application.Repositories.IExamRepository;
using Application.Repositories.IFacultyRepository;
using Application.Repositories.IGroupRepository;
using Application.Repositories.ILessonRepository;
using Application.Repositories.ISpecialtyRepository;
using Application.Repositories.IStudentRepository;
using Application.Repositories.ITeacherRepository;
using Application.Repositories.IUniversityRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IUnitOfWork
    {
        IReadUniversityRepository ReadUniversityRepository { get; }
        IWriteUniversityRepository WriteUniversityRepository { get; }

        IReadFacultyRepository ReadFacultyRepository { get; }
        IWriteFacultyRepository WriteFacultyRepository { get; }

        IReadSpecialtyRepository ReadSpecialtyRepository { get; }
        IWriteSpecialtyRepository WriteSpecialtyRepository { get; }

        IReadGroupRepository ReadGroupRepository { get; }
        IWriteGroupRepository WriteGroupRepository { get; }

        IReadStudentRepository ReadStudentRepository { get; }
        IWriteStudentRepository WriteStudentRepository { get;}

        IReadLessonRepository ReadLessonRepository { get; }
        IWriteLessonRepository WriteLessonRepository { get; }

        IReadExamRepository ReadExamRepository { get; }
        IWriteExamRepository WriteExamRepository { get; }

        IReadTeacherRepository ReadTeacherRepository { get; }
        IWriteTeacherRepository WriteTeacherRepository { get; }

        IReadDepartmentRepository ReadDepartmentRepository { get; }
        IWriteDepartmentRepository WriteDepartmentRepository { get; }
        
    }
}
