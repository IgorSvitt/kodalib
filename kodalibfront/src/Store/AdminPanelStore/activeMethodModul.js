export const activeMethod = {
    state: () => ({
        activeMethod: ""
    }),

    getters:{
        activeMethodReturn(state){
            return state.activeMethod
        }
    },

    mutations:{
        setActiveMethod(state, posts){
            state.activeMethod = posts
        }
    },

    action:{

    }
}