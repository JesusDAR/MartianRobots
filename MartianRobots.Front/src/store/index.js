import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    url : 'http://localhost:44307/api',
    error : '',
    mars : {
      x : -1,
      y : -1
    },
    robot : {
      x : -1,
      y : -1,
      or : '',
      movements : ''
    },
    robotOutput : {
      x : -1,
      y : -1,
      or : '',
    },
    information : {
      robotsLost : 0,
      robotsSucceeded : 0,
      surfaceExplored : 0,
      surfaceUnexplored : 0
    },
    output : '',
    visited : {}
  },
  mutations : {
    setMars(state, mars) {
      state.mars = mars
    },
    setRobot(state, robot) {
      state.robot = robot
    },
    setInformation(state, information) {
      state.information = information
    },    
    setRobotOutput(state, robotOutput) {
      state.robotOutput = robotOutput
    },         
    setMovements(state, movements) {
      state.robot.movements = movements
    }, 
    setError(state, error) {
      state.error = error
    },
    setOutput(state, output) {
      state.output = output
    },
    setVisited(state, visitedList) {
      state.visited = visitedList
    },            
  },

  actions : {
    async setMars(context, mars){
      let api = this.state.url + '/mars'
      return axios.post(api, mars, { headers : { 'Content-Type' : 'application/json'} } )
      .then( (response) => {
        if (response.data.error.message !== null)
          context.commit('setError', response.data.error.message)
        else
        {
          let mars = {
            x : response.data.x,
            y : response.data.y
          }
          context.commit('setMars', mars)
        }
      })
      .catch( (error) => {
        context.commit('setError', error.message)
      })

    },

    async sendRobot(context){
      let api = this.state.url + '/robot'
      return axios.post(api, this.state.robot, { headers : { 'Content-Type' : 'application/json'} } )
      .then( (response) => {
        if (response.data.error.message !== null)
          context.commit('setError', response.data.error.message)
        else
        {
          let robotOutput = {
            x : response.data.x,
            y : response.data.y,
            or : response.data.or
          }
          context.commit('setRobotOutput', robotOutput)
          let output = response.data.x + " " + response.data.y +  " " + response.data.or + (response.data.success === false ? " LOST " : "" ) + "\n" +  this.state.output
          context.commit('setOutput', output)
        }
      })
      .catch( (error) => {
        context.commit('setError', error.message)
      })
    },

    async deleteRobots(context){
      let api = this.state.url + '/robot'
      return axios.delete(api).catch( (error) => {
        context.commit('setError', error.message)
      })
    },

    async deleteInformation(context){
      let api = this.state.url + '/information'
      return axios.delete(api).catch( (error) => {
        context.commit('setError', error.message)
      })
    },

    async addInformation(context){
      let api = this.state.url + '/information'
      return axios.get(api)
      .then( (response) => {
        if (response.data.error.message !== null)
          context.commit('setError', response.data.error.message)
        else
        {
          let information = {
            robotsLost : response.data.robotsLost,
            robotsSucceeded : response.data.robotsSucceeded,
            surfaceExplored : response.data.surfaceExplored,
            surfaceUnexplored : response.data.surfaceUnexplored
          }
          context.commit('setInformation', information)
        }
      })
      .catch( (error) => {
        context.commit('setError', error.message)
      })
    },

    async getInformation(context){
      let api = this.state.url + '/information'
      return axios.post(api, this.state.information, { headers : { 'Content-Type' : 'application/json'} } )
      .then( (response) => {
        if (response.data.error.message !== null)
          context.commit('setError', response.data.error.message)
        else
        {
          let information = {
            robotsLost : response.data.robotsLost,
            robotsSucceeded : response.data.robotsSucceeded,
            surfaceExplored : response.data.surfaceExplored,
            surfaceUnexplored : response.data.surfaceUnexplored
          }
          context.commit('setInformation', information)
        }
      })
      .catch( (error) => {
        context.commit('setError', error.message)
      })
    },

    async deleteVisited(context){
      let api = this.state.url + '/visited'
      return axios.delete(api).catch( (error) => {
        context.commit('setError', error.message)
      })      
    },

    async getAllVisited(context){
      let api = this.state.url + '/visited'
      return axios.get(api).then( (response) => {
        console.log(response.data)
        context.commit('setVisited', response.data)
      })
      .catch( (error) => {
        context.commit('setError', error.message)
      })
    }
  },

  modules : {
  }
})
