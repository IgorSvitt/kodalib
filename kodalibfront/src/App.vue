<template>
  <div class="page-container">
    <koda-navbar  class="koda-navbar"/>
    <router-view/>
    <my-footer class="footer"/>
  </div>

</template>

<script>

import MyFooter from "@/components/UI/Footer/MyFooter";
import KodaNavbar from "@/components/UI/Navbar/KodaNavbar";
export default {
  components: {KodaNavbar, MyFooter}
}
</script>

<style>
* {
  font-family: 'Open Sans', sans-serif;
  padding: 0;
  margin: 0;
}

a {
  text-decoration: none;
}

body {
  background-color: #1B132E;
  display: flex;
  flex-direction: column;
  min-height: 100vh;
}

.container {
  max-width: 1320px;
  margin: 0 auto;
  flex: 1;
}

.footer {
  position: relative;
  bottom: 0;
  left: 0;
  right: 0;
  height: 140px; /* задайте нужную высоту футера */
}

.page-container {
  min-height: calc(100vh - 140px);
  overflow-y: auto;
}

@media (max-width: 1340px) {
  .container{
    max-width: 970px;
  }
}

@media (max-width: 1000px) {
  .container{
    max-width: 750px;
  }
}

@media (max-width: 752px) {
  .container{
    max-width: 360px;
  }
}

@media (max-width: 370px) {
  .container{
    max-width: none;
  }
}



</style>