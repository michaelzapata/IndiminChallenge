<template>
    <div>
        <h1>Vista de la Bruja</h1>
        <b-row>
            <b-col>
                <b-button variant="success" v-for="dayOfWeek in daysOfWeek" :key="dayOfWeek.id" @click="loadCitizenTaskByDayOfWeek(dayOfWeek.id)">{{ dayOfWeek.name }}</b-button>
            </b-col>
        </b-row>
        <b-row>
            <b-col>
                <b-card bg-variant="light" :header="daySelected" class="text-center">
                    <b-table v-if="citizenTasksByWeekDay.citizenTasks" stacked :items="citizenTasksByWeekDay.citizenTasks || []" :fields="fields">
                        <template #cell(tasks)="data">
                            <b class="text-info">{{ data.value.join(", ") }}</b>
                        </template>
                    </b-table>
                    <h2 v-else>No hay registros para este dia</h2>
                </b-card>
            </b-col>
        </b-row>
    </div>
</template>
<script>
export default {
    data() {
      return {
        fields: [
            { key : 'citizen.citizenName', label : 'Nombre y Apellido'},
            { key : 'tasks', label : 'Tareas'},
        ],
      }
    },
    computed : {
        daysOfWeek() {
            return this.$store.getters['getDaysOfweek']
        },
        citizenTasksByWeekDay(){
            return this.$store.getters['getCitizenTasksByWeekDay']
        },
        daySelected(){
            return this.$store.getters['getDayOfWeekNameSelected']
        },
    },
    mounted(){
        this.loadDaysOfWeek();
        this.loadCitizenTaskByDayOfWeek(new Date().getDay());
    },
    methods: {
        loadDaysOfWeek() {
            this.$store.dispatch('loadDayOfWeek')
        },
        loadCitizenTaskByDayOfWeek(dayOfWeek){
            this.$store.dispatch('loadCitizenTaskByDayOfWeek', dayOfWeek)
        }
    }
}
</script>