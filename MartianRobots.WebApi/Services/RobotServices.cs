using AutoMapper;
using MartianRobots.WebApi.DTOs;
using MartianRobots.WebApi.Services.Interfaces;
using MartianRobots.Core.Repositories.Interfaces;
using MartianRobots.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartianRobots.WebApi.Services
{
    public class RobotServices : IRobotServices
    {
        private readonly IRobotRepository _robotRepository;
        private readonly IMarsServices _marsServices;
        private readonly IVisitedServices _visitedServices;
        private readonly IMapper _mapper;
        public RobotServices(IRobotRepository robotRepository, IMarsServices marsServices, IVisitedServices visitedServices, IMapper mapper)
        {
            _mapper = mapper;
            _robotRepository = robotRepository;
            _marsServices = marsServices;
            _visitedServices = visitedServices;
        }
        public RobotOutputDTO MoveRobot(RobotInputDTO robotInputDTO)
        {
            RobotOutputDTO robotOutputDTO = new RobotOutputDTO 
            { 
                Error = new ErrorDTO { } 
            };
            Robot robot = new Robot { };

            try
            {
                robot = _mapper.Map<RobotInputDTO, Robot>(robotInputDTO, robot);

                robotOutputDTO = _mapper.Map<RobotOutputDTO>(robotInputDTO);
                robotOutputDTO.Error = new ErrorDTO { };
                MarsDTO marsDTO = _marsServices.GetMars();
                IEnumerable<RobotOutputDTO> robots = GetAll();
                IEnumerable<VisitedDTO> visited = _visitedServices.GetAll();
                VisitedDTO visitedDTO;
                if (!visited.Any(s => s.X == robotInputDTO.X && s.Y == robotInputDTO.Y))
                {
                    visitedDTO = new VisitedDTO
                    {
                        X = robotOutputDTO.X,
                        Y = robotOutputDTO.Y
                    };
                    _visitedServices.Add(visitedDTO);
                }

                foreach (char m in robotInputDTO.Movements)
                {
                    if (Constants.Movements.F.ToString().Equals(m.ToString()))
                    {
                        int x = robotOutputDTO.X;
                        int y = robotOutputDTO.Y;

                        if (robotOutputDTO.Or.Equals(Constants.Orientation.N.ToString()))
                            y++;
                        if (robotOutputDTO.Or.Equals(Constants.Orientation.E.ToString()))
                            x++;
                        if (robotOutputDTO.Or.Equals(Constants.Orientation.S.ToString()))
                            y--;
                        if (robotOutputDTO.Or.Equals(Constants.Orientation.W.ToString()))
                            x--;

                        if (robots.Any(s => s.X == x && s.Y == y && s.Success == false))
                        {
                            robotOutputDTO.Success = true;
                            robot = _mapper.Map<RobotOutputDTO, Robot>(robotOutputDTO, robot);
                            _robotRepository.Add(robot);
                            return robotOutputDTO;
                        }
                        else
                        {
                            robotOutputDTO.X = x;
                            robotOutputDTO.Y = y;
                        }

                        if (!visited.Any(s => s.X == x && s.Y == y))
                        {
                            visitedDTO = new VisitedDTO
                            {
                                X = robotOutputDTO.X,
                                Y = robotOutputDTO.Y
                            };
                            _visitedServices.Add(visitedDTO);
                        }
                    }

                    if (Constants.Movements.L.ToString().Equals(m.ToString()))
                    {
                        string Or = string.Empty;
                        if (robotOutputDTO.Or.Equals(Constants.Orientation.N.ToString()))
                            Or = Constants.Orientation.W.ToString();
                        if (robotOutputDTO.Or.Equals(Constants.Orientation.W.ToString()))
                            Or = Constants.Orientation.S.ToString();
                        if (robotOutputDTO.Or.Equals(Constants.Orientation.S.ToString()))
                            Or = Constants.Orientation.E.ToString();
                        if (robotOutputDTO.Or.Equals(Constants.Orientation.E.ToString()))
                            Or = Constants.Orientation.N.ToString();
                        robotOutputDTO.Or = Or;
                    }

                    if (Constants.Movements.R.ToString().Equals(m.ToString()))
                    {
                        string Or = string.Empty;
                        if (robotOutputDTO.Or.Equals(Constants.Orientation.N.ToString()))
                            Or = Constants.Orientation.E.ToString();
                        if (robotOutputDTO.Or.Equals(Constants.Orientation.E.ToString()))
                            Or = Constants.Orientation.S.ToString();
                        if (robotOutputDTO.Or.Equals(Constants.Orientation.S.ToString()))
                            Or = Constants.Orientation.W.ToString();
                        if (robotOutputDTO.Or.Equals(Constants.Orientation.W.ToString()))
                            Or = Constants.Orientation.N.ToString();
                        robotOutputDTO.Or = Or;
                    }

                    if ((robotOutputDTO.X > marsDTO.X || robotOutputDTO.X < 0) || (robotOutputDTO.Y > marsDTO.Y || robotOutputDTO.Y < 0))
                    {
                        robotOutputDTO.Success = false;
                        robot = _mapper.Map<RobotOutputDTO, Robot>(robotOutputDTO, robot);
                        _robotRepository.Add(robot);
                        return robotOutputDTO;
                    }
                }
                robotOutputDTO.Success = true;
                robot = _mapper.Map<RobotOutputDTO, Robot>(robotOutputDTO, robot);
                _robotRepository.Add(robot);
            }
            catch (Exception e)
            {
                robotOutputDTO.Error.Message = e.Message;
            }

            return robotOutputDTO;
        }
        public void DeleteRobots()
        {
            try
            {
                _robotRepository.Delete();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<RobotOutputDTO> GetAll()
        {
            try
            {
                return _robotRepository.GetAll().Select(s => _mapper.Map<RobotOutputDTO>(s));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
