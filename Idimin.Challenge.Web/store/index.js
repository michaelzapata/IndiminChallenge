import ServerFactory from "../servers/ServerFactory"

const BFF = ServerFactory.get("bffClient");
const CitizenClient = ServerFactory.get("citizenClient");
const TaskingClient = ServerFactory.get("taskingClient");

export const state = () => ({
    _citizens: [],
    _citizen : {
        id: null,
        firstName: null,
        lastName: null,
        isActive: true
    },
    _citizenTask : {
        id: null,
        citizenId: null,
        description: null,
        isActive: true,
        dayOfWeek: null
    },
    _daysOfWeek: [],
    _citizenTasksByWeekDay: {},
    _dayOfWeekNameSelected: "",
});

export const getters = {
    getCitizens(state){
        return state._citizens;
    },
    getCitizen(state){
        return state._citizen;
    },
    getDaysOfweek(state){
        return state._daysOfWeek;
    },
    getCitizenTasksByWeekDay(state){
        return state._citizenTasksByWeekDay;
    },
    getDayOfWeekNameSelected(state){
        return state._dayOfWeekNameSelected;
    }
}

export const mutations = {
    setDaysOfWeek(state, daysOfWeek){
        state._daysOfWeek = daysOfWeek;
    },
    setCitizen(state, citizen){
        state._citizen = citizen;
    },
    setCitizens(state, citizens){
        state._citizens = citizens;
    },
    setCitizenTasksByWeekDay(state, citizenTasksByWeekDay){
        state._citizenTasksByWeekDay = citizenTasksByWeekDay;
    },
    setDayOfWeekNameSelected(state, dayOfWeekNameSelected){
        state._dayOfWeekNameSelected = dayOfWeekNameSelected;
    },
    setFirstName(state, firstName){
        state._citizen.firstName = firstName;
    },
    setLastName(state, lastName){
        state._citizen.lastName = lastName;
    },
    setIsActive(state, isActive){
        state._citizen.isActive = isActive;
    },
    resetCitizen(state){
        state._citizen = {
            id: null,
            firstName: null,
            lastName: null,
            isActive: true
        }
    }
}

export const actions = {
    async loadCitizens(vuexContext){
        try {
            let response = await CitizenClient.citizensGET();
            vuexContext.commit("setCitizens", response.citizens);
        } catch(error) {
            vuexContext.commit("setCitizens", []);
        }
    },
    async saveCitizen(vuexContext){
        try {
            if(!vuexContext.state._citizen.id){
                await CitizenClient.citizensPOST({ 
                    firstName: vuexContext.state._citizen.firstName,
                    lastName: vuexContext.state._citizen.lastName,
                    isActive: vuexContext.state._citizen.isActive
                });
            } else {
                await CitizenClient.citizensPUT({ 
                    id: vuexContext.state._citizen.id,
                    firstName: vuexContext.state._citizen.firstName,
                    lastName: vuexContext.state._citizen.lastName,
                    isActive: vuexContext.state._citizen.isActive
                });
            }
            vuexContext.commit("resetCitizen");
            vuexContext.dispatch("loadCitizens");
        } catch(error) {
            console.log(error);
        }
    },
    async loadDayOfWeek(vuexContext){        
        try {
            let response = await BFF.dayOfWeekAll();
            vuexContext.commit("setDaysOfWeek", response);
        } catch(error){
            vuexContext.commit("setDaysOfWeek", []);
        }        
    },
    async loadCitizenTaskByDayOfWeek(vuexContext, dayOfWeek){
        try {
            let day = null;
            switch(dayOfWeek){
                case 0:
                    day = 7;
                    break;
                case 1:
                    day = 1;
                    break;
                case 2:
                    day = 2;
                    break;
                case 3:
                    day = 3;
                    break;
                case 4:
                    day = 4;
                    break;
                case 5:
                    day = 5;
                    break;
                case 6:
                    day = 6;
                    break;
            }
            let response = await BFF.dayOfWeek(day);
            vuexContext.commit("setCitizenTasksByWeekDay", response);
            vuexContext.commit("setDayOfWeekNameSelected", response.dayOfWeekData.name);
        } catch(error){
            vuexContext.commit("setCitizenTasksByWeekDay", {});
            vuexContext.commit("setDayOfWeekNameSelected", vuexContext.state._daysOfWeek.find( x => x.id == dayOfWeek).name);
        }
        
    }
}