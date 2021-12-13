<template>
  <div>
    <b-row>
      <b-col sm="6" md="6" lg="4">
        <b-card header="Ciudadanos" border-variant="primary">
          <b-form @submit="onSubmit" @reset="onReset">
            <b-row>
              <b-col sm="12" md="12" lg="12">
                <b-form-group id="nombreGroup"
                          label="Nombre:"
                          label-for="firstName">
                  <b-form-input id="firstName"
                                type="text"
                                :value="citizen.firstName"
																@input="setFirstName"
                                required
                                placeholder="Nombre">
                  </b-form-input>
                </b-form-group>
              </b-col>
            </b-row>

            <b-row>
              <b-col sm="12" md="12" lg="12">
                <b-form-group id="apellidoGroup"
                          label="Apellido:"
                          label-for="lastName">
                  <b-form-input id="lastName"
                                type="text"
                                :value="citizen.lastName"
																@input="setLastName"
                                required
                                placeholder="Apellido">
                  </b-form-input>
                </b-form-group>
              </b-col>
            </b-row>
            
            <b-row>
              <b-col sm="12" md="12" lg="12">
                 <b-form-checkbox id="isActive"
                                  :checked="citizen.isActive"
																	@input="setIsActive"
                                  unchecked-value="false">
                    Activo
                  </b-form-checkbox>
              </b-col>
            </b-row>
            <b-button type="submit" variant="primary">Guardar</b-button>
            <b-button type="reset" variant="danger">Cancelar</b-button>
          </b-form>
        </b-card>
      </b-col>
      <b-col v-show="citizens.length > 0" sm="6" md="6" lg="8">
        <b-card header="Ciudadanos" border-variant="primary">
          <b-table 
            striped hover 
            :items="citizens"
            :fields="citizenFields"
            :current-page="citizensCurrentPage"
            :per-page="citizenPerPage">
            <template v-slot:cell(actions)="row">
              <b-button size="sm" @click.stop="edit(row.item, row.index, $event.target)" variant="primary">
                Editar
              </b-button>
            </template>
          </b-table>
          <b-pagination align="center" :total-rows="citizens.length" :per-page="citizenPerPage" v-model="citizensCurrentPage" />
        </b-card>
      </b-col>
    </b-row>
  </div>
</template>
<script>

export default {
  data: function() {
    return {
      citizenFields: [
        { key: 'firstName', label: 'Nombre' },
        { key: 'lastName', label: 'Apellido' },
        { key: 'actions', label: 'Acciones' }
      ],
      citizensCurrentPage: 1,
      citizenPerPage: 10
    }
  },
  mounted(){
    this.loadCitizens();
  },
  computed:{
    citizens() {
      return this.$store.getters['getCitizens']
    },
    citizen() {
      return this.$store.getters['getCitizen']
    }
  },
  methods:{
    setFirstName(firstName){
      this.$store.commit('setFirstName', firstName);
    },
    setLastName(lastName){
      this.$store.commit('setLastName', lastName);
    },
    setIsActive(isActive){
      this.$store.commit('setIsActive', isActive);
    },
    loadCitizens(){
      this.$store.dispatch('loadCitizens');
    },
    saveCitizen(){
      this.$store.dispatch('saveCitizen');
    },
    onSubmit(evt) {
			evt.preventDefault();
			this.saveCitizen()
    },
    
    onReset(evt) {
      evt.preventDefault();
			this.$store.commit('resetCitizen');
      this.$nextTick(() => {
      });
    },
    
    edit (item, index, button) {
			this.$store.commit('setCitizen', item);
    },
  }
}
</script>