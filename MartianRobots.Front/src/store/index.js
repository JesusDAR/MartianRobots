import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    url: 'https://localhost:44307/api',
    error: '',
    mars: {
      x: 0,
      y: 0
    },
    robot: {
      x: 0,
      y: 0,
      or: '',
      movements: ''
    }
  },
  mutations: {
    setMars(state, mars) {
      state.mars = mars
    },
    setRobot(state, robot) {
      state.robot = robot
    },    
    setMovements(state, movements) {
      state.robot.movements = movements
    }, 
    setError(state, error) {
      state.error = error
    },
  },

  actions: {
    setMars(context, mars){
      let api = this.state.url + '/mars'
      axios.post(api, mars, { headers : { 'Content-Type' : 'application/json'} } )
      .then( (response) => {
        if (response.data.error.message !== null)
          context.commit('setError', response.data.error.message)
        else
        {
          let mars = {
            x: response.data.x,
            y: response.data.y
          }
          context.commit('setMars', mars)
        }
      })
      .catch( (error) => {
        context.commit('setError', error.message)
      })

    },

    sendRobot(context){
      let api = this.state.url + '/robot'
      axios.post(api, robot, { headers : { 'Content-Type' : 'application/json'} } )
      .then( (response) => {
        // if (response.data.error.message !== null)
        //   context.commit('setError', response.data.error.message)
        // else
        // {
        //   let mars = {
        //     x: response.data.x,
        //     y: response.data.y
        //   }
        //   context.commit('setMars', mars)
        // }
      })
      .catch( (error) => {
        context.commit('setError', error.message)
      })
    }
  },


  modules: {
  }
})
