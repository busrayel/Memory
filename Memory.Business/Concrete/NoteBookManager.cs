using AutoMapper;
using FluentValidation.Results;
using Memory.Business.Abstract;
using Memory.Business.DependencyResolves.ValidationRules.FluentValidation;
using Memory.DataAccess.Abstract;
using Memory.Entites.Concrete;
using Memory.Entites.Concrete.Dtos;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Business.Concrete
{
    public class NoteBookManager : INoteBookService
    {
        private readonly INotebookDal _notebookDal;
        private readonly IMapper _mapper;
        NotebookValidator rules = new NotebookValidator();

        public NoteBookManager(INotebookDal notebookDal,IMapper mapper)
        {
            _notebookDal = notebookDal;
            _mapper = mapper;
        }
       private ValidationResult Validate(Notebook notebook)
        {
            return rules.Validate(notebook);
        }
        public async Task<int> AddNotebookAsync(NoteBookDto notebookDto)
        {
            Notebook notebook = _mapper.Map<Notebook>(notebookDto);
            ValidationResult result = Validate(notebook);
            //Notebook notebook = NotebookDtoConvert(notebookDto);
            return await _notebookDal.AddAsync(notebook);
            
        }
        public Notebook NotebookDtoConvert(NoteBookDto notebookDto) 
        {
            return _mapper.Map<Notebook>(notebookDto);
        }
        public async Task<NoteBookDto> GetNotebookAsync(int id)
        {
            Notebook notebook = await _notebookDal.GetAsync(x=> x.Id == id);
            return _mapper.Map<NoteBookDto>(notebook);
        }

        public async Task<List<NoteBookDto>> GetNotebookListAsync()
        {
            List<Notebook> notebooks = await _notebookDal.GetAllAsync();
            List<NoteBookDto> noteBookDtos = new List<NoteBookDto>();
            foreach (Notebook item in notebooks)
            
                noteBookDtos.Add(_mapper.Map<NoteBookDto>(item));
                return noteBookDtos;
            
        }

        public async Task<int> RemoveNotebookAsync(NoteBookDto notebookDto)
        {
            Notebook notebook = _mapper.Map<Notebook>(notebookDto);
           return await _notebookDal.DeleteAsync(notebook);
        }

        public async Task<int> UpdateNotebookAsync(NoteBookDto notebookDto)
        {
            Notebook notebook = _mapper.Map<Notebook>(notebookDto);
            ValidationResult result = rules.Validate(notebook);
            return result.IsValid ? await _notebookDal.UpdateAsync(notebook) : 0;
        }
    }
}
