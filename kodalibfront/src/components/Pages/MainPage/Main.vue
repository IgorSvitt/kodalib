<template>
  <div class="bg">
    <div class="container">
      <new-episodes />
      <new-series />
      <new-films />
      <top-series />
      <top-films />
    </div>
  </div>
</template>

<script>
import NewEpisodes from "@/components/Pages/MainPage/New/NewEpisodes";
import NewSeries from "@/components/Pages/MainPage/New/NewSeries";
import NewFilms from "@/components/Pages/MainPage/New/NewFilms";
import TopSeries from "@/components/Pages/MainPage/Top/TopSeries";
import TopFilms from "@/components/Pages/MainPage/Top/TopFilms";

export default {
  name: "main-page",
  components: {TopFilms, TopSeries, NewFilms, NewSeries, NewEpisodes},
}
</script>

<style scoped>
.section-main {
  margin-top: 75px;
}

.bg-img{
  object-position: center center;
  object-fit: cover;
  width: 100%;
  height: 600px;
}

</style>