<template>
  <div class="container">
    <div class="title">
      Дорамы
    </div>
    <div class="films-filter">
      <div class="filters">
        <series-filters />
      </div>
      <div class="films">
        <list-of-series />
      </div>
    </div>
  </div>

</template>

<script>
import SeriesFilters from "@/components/Pages/AllSeriesPage/Filters/SeriesFilters";
import ListOfSeries from "@/components/Pages/AllSeriesPage/ListOfSeries";

export default {
  components: {ListOfSeries, SeriesFilters},
  setup(){
      document.title = "Дорамы";
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