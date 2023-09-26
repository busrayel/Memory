using Memory.DataAccess.Concrete.EntityFramework;
using Memory.Entites.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Business.Abstract
{
    public interface INoteBookService
    {
        Task<NoteBookDto> GetNotebookAsync(int id);

        Task<List<NoteBookDto>> GetNotebookListAsync();

        Task<int> AddNotebookAsync (NoteBookDto notebookDto);
        Task<int> RemoveNotebookAsync(NoteBookDto notebookDto);
        Task<int> UpdateNotebookAsync(NoteBookDto notebookDto);
    }
}
