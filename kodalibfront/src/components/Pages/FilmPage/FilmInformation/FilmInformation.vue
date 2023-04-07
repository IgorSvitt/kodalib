<template>
  <section>
    <title-film-information :filmInformation="filmInformation"/>
  </section>
  <section class="sections">
    <div class="left-section">
      <left-film-information :filmMedia="filmInformation"  />
    </div>
    <div class="center-section">
      <center-film-information :filmInformation="filmInformation" />
    </div>
    <div class="right-section">
      <right-film-information :actors="filmInformation.actors"/>
    </div>

  </section>
  <hr>
</template>

<script>
import TitleFilmInformation
  from "@/components/Pages/FilmPage/FilmInformation/TitleFilmInformation/TitleFilmInformation";
import LeftFilmInformation from "@/components/Pages/FilmPage/FilmInformation/Sections/LeftFilmInformation";
import CenterFilmInformation from "@/components/Pages/FilmPage/FilmInformation/Sections/CenterFilmInformation";
import RightFilmInformation from "@/components/Pages/FilmPage/FilmInformation/Sections/RightFilmInformation";
export default {
  name: "FilmInformation",
  components: {RightFilmInformation, CenterFilmInformation, LeftFilmInformation, TitleFilmInformation},
  props:{
    filmInformation: {
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