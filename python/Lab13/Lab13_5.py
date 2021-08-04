def get_rating(athlete, competition_points, olympic_competition):
    avarage = (competition_points[0] + competition_points[1] + competition_points[2] + competition_points[3] + competition_points[4] + competition_points[5]) / 6
    rating = 0.8 * avarage + 1.2 * olympic_competition
    print(f"Рейтинг спортсмена {athlete} рiвний {rating}.")
get_rating("Petrenko", (10, 9.5, 9.7, 9, 10, 9.3), 9.9)