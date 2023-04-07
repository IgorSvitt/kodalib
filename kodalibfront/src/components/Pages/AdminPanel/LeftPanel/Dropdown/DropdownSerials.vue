<template>
  <a class="dropdown-btn" @click="isActiveClick">Serials</a>
  <ul class="dropdown-show" :class="{ active: isActive }">
    <li><a href="">Get</a></li>
    <li><a href="">Create</a></li>
    <li><a href="">Update</a></li>
    <li><a href="">Delete</a></li>
  </ul>
</template>

<script>
import {ref} from "vue"

export default {
  setup() {
    const isActive = ref(false);

    function isActiveClick() {
      isActive.value = !isActive.value;
    }

    return {
      isActive,
      isActiveClick,
    };
  },
};
</script>

<style scoped>

*{
    box-sizing: border-box;
    user-select: none;
    list-style: none;
}

.dropdown-show{
    display: none;
}

.dropdown-show.active{
    display: block;
}

a{
    color:white;
    font-size: 18px;
    padding-left: 40px;
    font-weight: 400;
    display: block;
    width: 100%;
    border-left: 3px solid transparent;
}

a:hover {
  color: #ffddcc;
  background: #392661;
  border-left-color: #ffddcc;
}

nav ul ul li{
    line-height: 42px;
    border-bottom: none;
}

nav ul ul li a{
    font-size: 17px;
    padding-left: 80px;
}

nav ul ul {
    position: static;
    display: none;
}

</style>