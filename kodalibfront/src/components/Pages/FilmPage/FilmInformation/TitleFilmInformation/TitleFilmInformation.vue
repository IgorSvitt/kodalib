<template>
  <div class="title-information">
    <div class="title-rating">
      <div class="film-title">
        {{ filmInformation.title }}
      </div>
      <div class="film-rating-large">
        <div class="rating">
          <div class="rating-text">
            Рейтинг Kodalib
          </div>
          <div class="rating-number">
            <span class="active">{{ filmInformation.ratingKoda }}</span><span class="passive">/10</span>
          </div>
        </div>
        <div class="rating">
          <div class="rating-text">
            Рейтинг КП
          </div>
          <div class="rating-number">
            <span class="active">{{ filmInformation.kinopoiskRating }}</span><span class="passive">/10</span>
          </div>
        </div>
      </div>
    </div>
    <div class="all-information">
      <div class="film-information">
        Фильм • {{ filmInformation.year }} • {{ filmInformation.duration }} мин
      </div>
      <div class="film-country">
        {{ filmInformation.countries.join(' • ') }}
      </div>
    </div>

    </div>
  <div class="film-rating-small">
    <div class="rating">
      <div class="rating-text">
        Рейтинг Kodalib
      </div>
      <div class="rating-number">
        <span class="active">{{ filmInformation.ratingKoda }}</span><span class="passive">/10</span>
      </div>
    </div>
    <div class="rating">
      <div class="rating-text">
        Рейтинг КП
      </div>
      <div class="rating-number">
        <span class="active">{{ filmInformation.kinopoiskRating }}</span><span class="passive">/10</span>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "TitleFilmInformation",
  props: {
    filmInformation: {
      type: Object
    }
  },

}
</script>

<style scoped>
.film-title {
  font-size: 36px;
  font-weight: bold;
  color: #efefef;
}

.title-information {
  color: #efefef;
  font-size: 16px;
}

.title-rating {
  display: flex;
  justify-content: space-between;
}

.film-rating-large {
  display: flex;
}

.film-rating-small {
  display: none;
}

.rating {
  display: block;
  width: 150px;
}

.rating-text, .rating-number {
  font-size: 18px;
  width: 100%;
  color: #efefef;
  text-align: center;
}

.rating-number .active {
  font-size: 20px;
  font-weight: 600;
}

.rating-number .passive {
  font-size: 17px;
  color: rgba(255, 255, 255, 0.5);
}

@media (max-width: 1000px) {
  .film-title {
    font-size: 28px;
  }

  .all-information{
    margin: 10px 0;
    font-size: 14px;
  }

  .rating {
    display: inline-block;
    width: 150px;
  }

  .rating-text, .rating-number {
    font-size: 16px;
    display: inline-block;
  }

  .rating-number .active {
    font-size: 18px;
  }

  .rating-number .passive {
    font-size: 16px;
  }


}

@media (max-width: 752px){

  .title-rating {
    display: block;
  }
  .film-rating-large {
    display: none;
  }

  .film-rating-small {
    display: inline-block;
  }
}
</style>