<template>
  <div class="right-panel">
    <dropdown-method-film-get v-if="activeMethod === 'getFilm'"/>
    <dropdown-method-film-create v-if="activeMethod === 'createFilm'"/>
    <dropdown-method-film-update v-if="activeMethod === 'updateFilm'" />
    <dropdown-method-film-delete  v-if="activeMethod === 'deleteFilm'" />
    <dropdown-method-person-get v-if="activeMethod === 'getPerson'" />
    <dropdown-method-person-delete v-if="activeMethod === 'deletePerson'" />
    <dropdown-method-person-create v-if="activeMethod === 'createPerson'" />
    <dropdown-method-person-update v-if="activeMethod === 'updatePerson'" />

  </div>

</template>

<script>
import DropdownMethodFilmGet from './DropdownMethods/Film/GetFilm/DropdownMethodFilmGet.vue'
import DropdownMethodFilmCreate from "@/components/Pages/AdminPanel/RightPanel/DropdownMethods/Film/CreateFilm/DropdownMethodFilmCreate";
import DropdownMethodFilmUpdate from "@/components/Pages/AdminPanel/RightPanel/DropdownMethods/Film/UpdateFilm/DropdownMethodFilmUpdate";
import DropdownMethodFilmDelete from "@/components/Pages/AdminPanel/RightPanel/DropdownMethods/Film/DeleteFilm/DropdownMethodFilmDelete";
import {useStore} from "vuex";
import {computed} from "vue";
import DropdownMethodPersonGet from "@/components/Pages/AdminPanel/RightPanel/DropdownMethods/Person/GetPerson/DropdownMethodPersonGet";
import DropdownMethodPersonDelete
  from "@/components/Pages/AdminPanel/RightPanel/DropdownMethods/Person/DeletePerson/DropdownMethodPersonDelete";
import DropdownMethodPersonCreate
  from "@/components/Pages/AdminPanel/RightPanel/DropdownMethods/Person/CreatePerson/DropdownMethodPersonCreate";
import DropdownMethodPersonUpdate
  from "@/components/Pages/AdminPanel/RightPanel/DropdownMethods/Person/UpdatePerson/DropdownMethodPersonUpdate";


export default {
  components: {
    DropdownMethodPersonUpdate,
    DropdownMethodPersonCreate,
    DropdownMethodPersonDelete,
    DropdownMethodPersonGet,
    DropdownMethodFilmUpdate, DropdownMethodFilmCreate, DropdownMethodFilmGet, DropdownMethodFilmDelete},
  setup(){
    const store = useStore()

    const activeMethod = computed(()=> store.getters.activeMethodReturn)

    return{
      activeMethod
    }
  }
}
</script>

<style>
.right-panel {
  background-color: #fff;
  width: 1100px;
}

</style>