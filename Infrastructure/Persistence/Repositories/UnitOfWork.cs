using Application.Repositories;
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

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IReadUniversityRepository readUniversityRepository, IWriteUniversityRepository writeUniversityRepository, IReadFacultyRepository readFacultyRepository, IWriteFacultyRepository writeFacultyRepository, IReadSpecialtyRepository readSpecialtyRepository, IWriteSpecialtyRepository writeSpecialtyRepository, IReadGroupRepository readGroupRepository, IWriteGroupRepository writeGroupRepository, IReadStudentRepository readStudentRepository, IWriteStudentRepository writeStudentRepository, IReadLessonRepository readLessonRepository, IWriteLessonRepository writeLessonRepository, IReadExamRepository readExamRepository, IWriteExamRepository writeExamRepository, IReadTeacherRepository readTeacherRepository, IWriteTeacherRepository writeTeacherRepository, IReadDepartmentRepository readDepartmentRepository, IWriteDepartmentRepository writeDepartmentRepository)
        {
            ReadUniversityRepository = readUniversityRepository;
            WriteUniversityRepository = writeUniversityRepository;
            ReadFacultyRepository = readFacultyRepository;
            WriteFacultyRepository = writeFacultyRepository;
            ReadSpecialtyRepository = readSpecialtyRepository;
            WriteSpecialtyRepository = writeSpecialtyRepository;
            ReadGroupRepository = readGroupRepository;
            WriteGroupRepository = writeGroupRepository;
            ReadStudentRepository = readStudentRepository;
            WriteStudentRepository = writeStudentRepository;
            ReadLessonRepository = readLessonRepository;
            WriteLessonRepository = writeLessonRepository;
            ReadExamRepository = readExamRepository;
            WriteExamRepository = writeExamRepository;
            ReadTeacherRepository = readTeacherRepository;
            WriteTeacherRepository = writeTeacherRepository;
            ReadDepartmentRepository = readDepartmentRepository;
            WriteDepartmentRepository = writeDepartmentRepository;
        }

        public IReadUniversityRepository ReadUniversityRepository { get; }

        public IWriteUniversityRepository WriteUniversityRepository { get; }

        public IReadFacultyRepository ReadFacultyRepository { get; }

        public IWriteFacultyRepository WriteFacultyRepository { get; }

        public IReadSpecialtyRepository ReadSpecialtyRepository { get; }

        public IWriteSpecialtyRepository WriteSpecialtyRepository { get; }

        public IReadGroupRepository ReadGroupRepository { get; }

        public IWriteGroupRepository WriteGroupRepository { get; }

        public IReadStudentRepository ReadStudentRepository { get; }

        public IWriteStudentRepository WriteStudentRepository { get; }

        public IReadLessonRepository ReadLessonRepository { get; }

        public IWriteLessonRepository WriteLessonRepository { get; }

        public IReadExamRepository ReadExamRepository { get; }

        public IWriteExamRepository WriteExamRepository { get; }

        public IReadTeacherRepository ReadTeacherRepository { get; }

        public IWriteTeacherRepository WriteTeacherRepository { get; }

        public IReadDepartmentRepository ReadDepartmentRepository { get; }

        public IWriteDepartmentRepository WriteDepartmentRepository { get; }
    }
}
