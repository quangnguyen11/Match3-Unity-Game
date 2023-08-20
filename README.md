Project cần cải thiện:
- Logic sử dụng quá nhiều vòng for lồng nhau gây ảnh hưởng đến hiệu năng nên thiết kế lại logic
- Class UI Manager nên chứa tất cả các UI (Main, Game, Pause) và load lên theo từng kịch bản cụ thể không nên để ở Hirerachy Set Active On/Off
- Các item trong game (normal1 - 7, bomd, ...) không nên tách riêng prefab mà nên để chung 1 prefab rồi load icon tương ứng lên
- Dùng thư viện DOTween nên bật Log Behaviour -> verbose để debug
- Hạn chế dùng IEnumerator chỉ để delay nếu muốn delay thực thi function nào đó có thể dùng Invoke
- Có thể tối ưu khi dùng coroutine với thư viện https://assetstore.unity.com/packages/tools/animation/more-effective-coroutines-free-54975 nên kiểm soát số lượng vào vòng đời của coroutine chặt chẽ tránh làm đầy bộ nhớ
  
