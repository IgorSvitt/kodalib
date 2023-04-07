<template>
  <div class="container">
    <div class="title">
      Фильмы
    </div>
    <div class="films-filter">
      <div class="filters">
        <filters/>
      </div>
      <div class="films">
        <list-of-films/>
      </div>
    </div>
  </div>

</template>

<script>
import ListOfFilms from "@/components/Pages/FilmsPage/ListFilms/ListOfFilms";
import Filters from "@/components/Pages/FilmsPage/Filters/Filters";

export default {
  name: "FilmsPage",
  components: {Filters, ListOfFilms},
  setup(){
    document.title = "Фильмы";
  }
}
</script>

<style scoped>
.films-filter {
  display: flex;
}

.container {
  margin-top: 75px;
}

.title {
  font-size: 40px;
  color: #efefef;
  text-align: center;
  margin-bottom: 20px;
}

.filters {
  width: 25%;
  margin-right: 20px;
}

.films {
  width: 75%;
  min-height: calc(100vh - 215px);
}


@media (max-width: 1000px) {
  .films-filter {
    display: block;
  }

  .films, .filters {
    width: 100%;
  }

  .filters{
    margin-bottom: 20px;
  }
}



</style>