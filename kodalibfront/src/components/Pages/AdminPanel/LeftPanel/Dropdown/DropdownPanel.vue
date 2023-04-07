<template>
  <nav class="sidebar">
    <ul>
      <li>
        <dropdown-film></dropdown-film>
      </li>
      <li>
        <dropdown-serials></dropdown-serials>
      </li>
      <li>
        <dropdown-actors></dropdown-actors>
      </li>
      <li>
        <dropdown-users></dropdown-users>
      </li>
    </ul>
  </nav>
</template>

<script>
import DropdownActors from './DropdownActors.vue';
import DropdownFilm from './DropdownFilm.vue';
import DropdownSerials from "./DropdownSerials.vue"
import DropdownUsers from './DropdownUsers.vue';
export default {
  components: { DropdownFilm , DropdownSerials, DropdownActors, DropdownUsers},
  name: "dropdown-panel",


};
</script>

<style scoped>
*{
    box-sizing: border-box;
    user-select: none;
    list-style: none;
}

nav ul{
    height: 100%;
    width: 100%;
}

nav ul li{
    line-height: 60px;
    border-bottom: 1px solid rgba(255,255,255,0.1);
}

</style>