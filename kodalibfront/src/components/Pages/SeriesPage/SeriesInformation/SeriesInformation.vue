<template>
  <section>
    <title-series-information :series-information="seriesInformation"/>
  </section>
  <section class="sections">
    <div class="left-section">
      <left-series-information :series-media="seriesInformation"/>
    </div>
    <div class="center-section">
      <center-series-information :series-information="seriesInformation"/>
    </div>
    <div class="right-section">
      <right-series-informetion :actors="seriesInformation.actors" />
    </div>

  </section>
  <hr>
</template>

<script>
import TitleSeriesInformation
  from "@/components/Pages/SeriesPage/SeriesInformation/TitleSeriesInformation/TitleSeriesInformation";
import LeftSeriesInformation from "@/components/Pages/SeriesPage/SeriesInformation/Section/LeftSeriesInformation";
import RightSeriesInformetion from "@/components/Pages/SeriesPage/SeriesInformation/Section/RightSeriesInformetion";
import CenterSeriesInformation from "@/components/Pages/SeriesPage/SeriesInformation/Section/CenterSeriesInformation";
export default {
  name: "FilmInformation",
  components: {
    CenterSeriesInformation,
    RightSeriesInformetion, LeftSeriesInformation, TitleSeriesInformation},
  props:{
    seriesInformation: {
      type: Object,
      required: true,
    }
  }
}
</script>

<style scoped>
.sections{
  display: flex;
  margin-top: 25px;
  margin-bottom: 45px;
}

.left-section{
  width: 290px;
}

.center-section{
  width: 640px;
  margin: 0 20px;
}

.right-section{
  width: 310px;
}

hr{
  color: #efefef;
  width: 1000px;
}


@media (max-width: 1340px) {
  .left-section{
    width: 230px;
  }

  .center-section{
    width: 430px;
    margin: 0 20px;
  }

  .right-section{
    width: 230px;
  }

  hr{
    color: #efefef;
    width: auto;
  }
}

@media (max-width: 1000px) {
  .left-section{
    width: 270px;
  }

  .center-section{
    width: 400px;
    margin: 0 0 0 30px;
  }

  .right-section{
    display: none;
  }
}

@media (max-width: 752px) {
  .sections{
    display: block;
    margin-top: 25px;
    margin-bottom: 45px;
  }

  .left-section{
    width: 320px;
    margin-bottom: 40px;
  }

  .center-section{
    width: 320px;
    margin: 0;
  }

  .right-section{
    width: 320px;
    display: inline-block;
  }
}

</style>