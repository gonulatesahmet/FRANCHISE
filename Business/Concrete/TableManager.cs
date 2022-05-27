using Business.Abstract;
using Business.Constants;
using Core.Utilites.Results;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Combobox;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class TableManager : ITableService
    {
        ITableDal _tableDal;
        public TableManager(ITableDal tableDal)
        {
            _tableDal = tableDal;
        }
        public IResult Add(Table entity)
        {
            IResult control = BusinessRules.Run(TableAddEntityControl(entity));
            if(control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _tableDal.Add(entity);
                return new SuccessResult(Messages.TableAdded);
            }
        }

        public IResult ChangeState(int id, bool state)
        {
            IResult control = BusinessRules.Run(TableIdControl(id));
            if(control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _tableDal.ChangeState(id, state);
                return new SuccessResult(Messages.TableChangeState);
            }
        }

        public IResult Delete(int id)
        {
            IResult control = BusinessRules.Run(TableIdControl(id));
            if(control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _tableDal.Delete(id);
                return new SuccessResult(Messages.TableDeleted);
            }
        }

        public IDataResult<List<Table>> GetAll(int? id)
        {
            return new SuccessDataResult<List<Table>>(_tableDal.GetAll(id), Messages.TableGetAll);
        }

        public IDataResult<Table> GetById(int id)
        {
            IResult control = BusinessRules.Run(TableIdControl(id));
            if (control != null)
            {
                return new ErrorDataResult<Table>(control.Message);
            }
            else
            {
                return new SuccessDataResult<Table>(_tableDal.GetById(id), Messages.TableGetById);
            }
        }
        public IResult Update(Table entity)
        {
            IResult control = BusinessRules.Run(TableUpdateEntityControl(entity));
            if(control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _tableDal.Update(entity);
                return new SuccessResult(Messages.TableUpdated);
            }
        }




        public IDataResult<List<TableDto>> TableDtoGetByArea(int AreaId)
        {
            IResult control = BusinessRules.Run(TableIdControl(AreaId));
            if(control != null)
            {
                return new ErrorDataResult<List<TableDto>>(control.Message);
            }
            else
            {
                return new SuccessDataResult<List<TableDto>>(_tableDal.TableDtoGetByArea(AreaId), Messages.TableGetArea);
            }
        }

        public IDataResult<List<CbbTable>> CbbTableGetByArea(int areaId, bool state)
        {
            IResult control = BusinessRules.Run(TableIdControl(areaId));
            if(control != null)
            {
                return new ErrorDataResult<List<CbbTable>>(control.Message);
            }
            else
            {
                return new SuccessDataResult<List<CbbTable>>(_tableDal.CbbTableGetByArea(areaId, state), Messages.TableGetAll);
            }
        }

        public IResult TableChangeDisplay(int tableId, bool display)
        {
            IResult control = BusinessRules.Run(TableIdControl(tableId));
            if(control != null)
            {
                return new ErrorResult(control.Message);
            }
            else
            {
                _tableDal.TableChangeDisplay(tableId, display);
                return new SuccessResult(Messages.TableUpdated);
            }
        }

        public IDataResult<List<Table>> TableGetByArea(int areaId, bool state)
        {
            IResult control = BusinessRules.Run(TableIdControl(areaId));
            if(control != null)
            {
                return new ErrorDataResult<List<Table>>(control.Message);
            }
            else
            {
                return new SuccessDataResult<List<Table>>(_tableDal.TableGetByArea(areaId, state), Messages.TableGetAll);
            }
        }



        //Rules
        private IResult TableUpdateEntityControl(Table entity)
        {
            if (string.IsNullOrEmpty(entity.TableName)) return new ErrorResult(Messages.NameCannotBeEmpty);
            if (string.IsNullOrEmpty(entity.TableCode)) return new ErrorResult(Messages.CodeCannotBeEmpty);
            if (string.IsNullOrEmpty(entity.TableDescription)) return new ErrorResult(Messages.DescriptionCannotBeEmpty);
            return new SuccessResult();
        }
        private IResult TableAddEntityControl(Table entity)
        {
            TableUpdateEntityControl(entity);
            if(entity.AreaId == 0) return new ErrorResult(Messages.IdNotFound);
            return new SuccessResult();
        }
        private IResult TableIdControl(int id)
        {
            if(id == 0) return new ErrorResult(Messages.IdNotFound);
            return new SuccessResult();
        }
    }
}
